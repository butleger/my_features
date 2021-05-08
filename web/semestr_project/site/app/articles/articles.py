from flask import Blueprint, render_template, abort
from articles.controllers import ArticleController, ArticlePickerController


articles = Blueprint("articles", __name__)


@articles.route('/')
def default_path():
    return ArticlePickerController.get_response()


@articles.route('/picker')
def picker_wrapper():
    return ArticlePickerController.get_response()


@articles.route('/<article_id>')
def article_wrapper(article_id):
    return ArticleController.get_response(article_id=article_id) 