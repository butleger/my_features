from flask import render_template, request, abort
from articles.forms import ArticleCommentForm
from base.models import Header, Article, User, ArticleComment
from base.controllers import BaseController
from sqlalchemy.sql import text
from werkzeug.exceptions import HTTPException


class ArticlePickerController(BaseController):
    template = "articles/picker.html"
    context  = { "articles": Article.query.all() }


class ArticleController(BaseController):
    template = "articles/article.html"

    @classmethod
    def get_context(cls, *args, **kwargs):
        cls.base_context["article"] = Article.query.get(kwargs["article_id"])
        if cls.base_context["article"] is None:
            abort(404)
        cls.base_context["author"] = User.query.filter_by(
            id=cls.base_context["article"].user_id
        ).first()
        cls.base_context["comments"] = ArticleComment.query.filter_by(
            article_id=cls.base_context["article"].id
        ).all()
        cls.base_context["form"] = ArticleCommentForm()
        return super().get_context()
