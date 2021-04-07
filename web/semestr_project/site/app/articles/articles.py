from flask import Blueprint, render_template, abort
from articles.views import *


articles = Blueprint("articles", __name__)


@articles.route('/')
def default_path():
    return article_picker()


@articles.route('/picker')
def picker_wrapper():
    return article_picker()


@articles.route('/<article_name>')
def article_wrapper(article_name):
    return article(article_name) 