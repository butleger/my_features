from flask import render_template, request, flash, redirect
from flask_login import login_user, current_user, login_required, logout_user
from werkzeug.security import generate_password_hash
from base.models import User, Header, Article
from extensions import login_manager, db
from base.controllers import BaseController
from auth.forms import LoginForm, CreateArticleForm, CreateUserForm
from auth.user_login import UserLogin


@login_manager.user_loader
def load_user(user_id):
    user = User.query.get(user_id)
    return user


@login_manager.unauthorized_handler
def unauthorized():
    return redirect("/auth/login")


class OnlyLoggedController(BaseController):
    @classmethod
    @login_required
    def get_response(cls):
        return super().get_response()


class HomeController(OnlyLoggedController):
    template = "auth/home.html"



class LoginController(BaseController):
    template = "auth/login.html"
    
    @classmethod
    def get_context(cls):
        cls.base_context["form"] = LoginForm()
        return super().get_context()


    @classmethod
    def POST(cls):
        name = request.form.get("login")
        password = request.form.get("password")
        context = cls.get_context()
        if not User.try_login(name, password):
            flash("Invalid password or username!", "error")
        return render_template(cls.template, **context), cls.status


class LogOutController(OnlyLoggedController):
    
    @classmethod
    def GET(cls):
        logout_user()
        return redirect("/auth/login")


class LoginAjaxController(BaseController):
    @classmethod
    def get_response(cls):
        print(f"nickname = {request.form.get('login')}")
        print(f"password = {request.form.get('password')}")
        return "All is ok!"


class CreateArticleController(OnlyLoggedController):
    template = "auth/create_article.html"

    @classmethod
    def POST(cls, *args, **kwargs):
        article = Article()
        article.title       = request.form.get("title")
        article.text        = request.form.get("article")
        article.user_id     = current_user.id
        article.author_name = current_user.nickname
        
        db.session.add(article)
        db.session.commit()
        return cls.GET(*args, **kwargs) 


    @classmethod
    def get_context(cls, *args, **kwargs):
        cls.base_context["form"] = CreateArticleForm()
        return super().get_context()



class CreateUserController(OnlyLoggedController):
    template = 'auth/create_user.html'


    @classmethod
    def get_context(cls):
        cls.base_context['form'] = CreateUserForm()
        return super().get_context()


    @classmethod
    def GET(cls, *args, **kwargs):
        context = cls.get_context()
        if (current_user.nickname != "Fedor"): # fedor is admin 
            return redirect("/auth/home")
        else :
            return render_template(cls.template, **context), 200


    @classmethod
    def POST(cls, *args, **kwargs):
        new_user = User()
        form = request.form
        new_user.nickname = form.get('nickname')
        new_user.password_hash = generate_password_hash(form.get('password'))
        new_user.image_url = form.get('image_url')
        new_user.about = form.get('about')
        new_user.footer_text = form.get('footer')
        new_user.email = form.get('email')

        db.session.add(new_user)
        db.session.commit()
        return cls.GET(*args, **kwargs)
