from flask import render_template, request, flash, redirect
from flask_login import login_user, current_user, login_required
from base.models import User, Header
from extensions import login_manager
from base.controllers import BaseController
from auth.forms import LoginForm, CreateArticleForm
from auth.user_login import UserLogin


@login_manager.user_loader
def load_user(user_id):
    user = User.query.filter_by(id=user_id).first()
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
    def POST(cls):
        name = request.form.get("login")
        password = request.form.get("password")
        user = UserLogin().from_db(name, password)
        context = cls.get_context()
        if user is None:
            flash("Invalid password or username!", "error")
        else : 
            login_user(user)
        return render_template(cls.template, **context, form=LoginForm()), cls.status


class LoginAjaxController(BaseController):
    @classmethod
    def get_response(cls):
        print(f"nickname = {request.form.get('login')}")
        print(f"password = {request.form.get('password')}")
        return "All is ok!"


class CreateArticleController(OnlyLoggedController):
    template = "auth/create_article.html"

    @classmethod
    def get_view(cls):
        def view(*args, **kwargs):
            context = cls.get_context()
            if request.method == 'POST':
                user = UserLogin.from_db()
            return render_template(cls.template, **context, form=CreateArticleForm())
        return view