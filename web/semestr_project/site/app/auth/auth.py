from flask import Blueprint, render_template, abort, request
from auth.views import *

auth = Blueprint("auth", __name__)

@auth.route('/home')
def home_wrapper():
    return home()


@auth.route('/login', methods=['GET', 'POST'])
def login_wrapper():
    return login()


@auth.route('/create_article', methods=['GET', 'POST'])
def create_article_wrapper():
    return create_article()
