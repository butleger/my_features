from flask import render_template, request, abort
from flask_login import current_user
from articles.forms import ArticleCommentForm
from base.models import Header, Article, User, ArticleComment
from base.controllers import BaseController
from auth.controllers import OnlyLoggedController
from sqlalchemy.sql import text
from werkzeug.exceptions import HTTPException
from extensions import db


class ArticlePickerController(BaseController):
    template = "articles/picker.html"

    @classmethod
    def get_context(cls, *args, **kwargs):
        cls.base_context["articles"] = Article.query.all()
        return super().get_context()


class ArticleController(BaseController):
    template = "articles/article.html"

    @classmethod
    def POST(cls, *args, **kwargs):
        if request.form is not None:
            if current_user.is_authenticated: 
                comment = ArticleComment()
                comment.text = request.form.get("comment")
                comment.user_id = current_user.get_id()
                comment.article_id = int(request.url.split('/')[-1]) # last element of url
                print(f"comment.article_id = {comment.article_id}")
                db.session.add(comment)
                db.session.commit()


        return cls.GET(*args, **kwargs)

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
        cls.base_context["comment_url"] = f"{request.url}"
        return super().get_context()


class ArticleAddLike(BaseController):
    @classmethod
    def POST(cls, *args, **kwargs):
        article_id = kwargs['article_id']
        article = Article.query.get(article_id)
        if article is None: 
            return render_template("errors/empty.html"), 404
        else:
            article.likes = int(article.likes) + 1
            db.session.commit()
            return render_template("errors/empty.html"), 200



class ArticleCommentAddLike(BaseController):
    @classmethod
    def POST(cls, *args, **kwargs):
        comment_id = kwargs['comment_id']
        comment = ArticleComment.query.get(comment_id)
        if comment is None: 
            return render_template("errors/empty.html"), 404
        else:
            comment.likes = int(comment.likes) + 1
            db.session.commit()
            return render_template("errors/empty.html"), 200
