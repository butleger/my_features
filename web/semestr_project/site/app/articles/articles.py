from flask import Blueprint, render_template, abort
from articles.controllers import ArticleController, ArticlePickerController, ArticleAddLike, ArticleCommentAddLike


articles = Blueprint("articles", __name__)


@articles.route('/')
def default_path():
    return ArticlePickerController.get_response()


@articles.route('/picker')
def picker_wrapper():
    return ArticlePickerController.get_response()


@articles.route('/<article_id>', methods=["GET", "POST"])
def article_wrapper(article_id):
    return ArticleController.get_response(article_id=article_id) 


@articles.route('/add_like/<article_id>', methods=['POST'])
def add_like_wrapper(article_id):
    return ArticleAddLike.get_response(article_id=article_id)


@articles.route('/comments/add_like/<comment_id>', methods=['POST'])
def add_comment_like_wrapper(comment_id):
    return ArticleCommentAddLike.get_response(comment_id=comment_id)