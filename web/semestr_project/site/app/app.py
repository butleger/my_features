from flask import Flask, render_template, request
from config import config
import datetime
import os

'''
def create_app():
    app = Flask(__name__, static_folder="static", template_folder="templates")
    app.config.from_object(config)
    register_blueprints(app)
    return app


def register_extensions(app):
    from app.extensions import db 
    db.init_app(app)
    db.app = app


def register_blueprints(app):
    from articles.articles import articles
    from common.common import common
    from forum.forum import forum
    from auth.auth import auth

    app.register_blueprint(articles, url_prefix="/articles")
    app.register_blueprint(common, url_prefix="/common")
    app.register_blueprint(forum, url_prefix="/forum")
    app.register_blueprint(auth, url_prefix="/auth")


app = create_app()
'''

def create_app():
    app = Flask(__name__, static_folder="static", template_folder="templates")
    app.config.from_object(config)
    register_extensions(app)
    register_blueprints(app)
    return app


def register_extensions(app):
    from extensions import db
    db.init_app(app)
    db.app = app
    

def register_blueprints(app):
    from auth.auth import auth
    from forum.forum import forum
    from common.common import common
    from articles.articles import articles

    app.register_blueprint(auth, url_prefix='/auth')
    app.register_blueprint(forum, url_prefix='/forum')
    app.register_blueprint(common, url_prefix='/common')
    app.register_blueprint(articles, url_prefix='/articles')


app = create_app()

if __name__ == '__main__':
    app.debug = True
    app.run('127.0.0.1')
