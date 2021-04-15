from flask import render_template, request
from base.models import User, Header
from extensions import login_manager
from auth.forms import *
from auth.user_login import UserLogin


@login_manager.user_loader
def load_user(user_id):
    return UserLogin.from_db(user_id)


class HomeController(BaseController):
    template = "auth/home.html"


class LoginController(BaseController):
    template = "auth/login.html"

    @classmethod
    def get_view(cls):
        def view(*args, **kwargs):
            context = cls.get_context()
            if request.method == 'POST':
                user = UserLogin.from_db()
            return render_template(cls.template, **context, form=LoginForm())
        return view
