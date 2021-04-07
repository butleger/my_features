from flask import render_template, request
from base.models import User, Header
from auth.forms import *

context = {
    'headers': Header.query.all(),
}


def rules():
    return render_template("common/rules.html", **context)


def home():
    return render_template("auth/home.html", **context)



def login():
    return render_template("auth/login.html", **context, form=LoginForm())


def create_article():
    if request.method == 'POST':
        print('title = ' + request.form.get('title'))
        print('article = ' + request.form.get('article'))
    return render_template("auth/create_article.html", **context, form=CreateArticleForm())

