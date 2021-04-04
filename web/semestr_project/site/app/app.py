from forms import LoginForm, ArticleCommentForm, ForumCommentForm, CreateArticleForm
from flask import Flask, flash, request, render_template
from flask import g
from extensions import db
from config import config
from flask_sqlalchemy import SQLAlchemy
from views import *
import os


def create_app():
    app = Flask(__name__, static_folder="static", template_folder="templates")
    app.config.from_object(config)
    register_blueprints(app)
    return app



def register_blueprints(app):
    from articles.articles import articles
    from common.common import common
    from forum.forum import forum
    from auth.auth import auth

    app.register_blueprint(articles)
    app.register_blueprint(common)
    app.register_blueprint(forum)
    app.register_blueprint(auth)


app = create_app()

app.add_url_rule('/', 'index', IndexView.index)

if __name__ == '__main__':
    app.debug = True
    app.run('127.0.0.1')
