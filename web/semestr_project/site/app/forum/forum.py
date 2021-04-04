from flask import Blueprint, render_template, abort

forum = Blueprint("forum", __name__)


@forum.route('/picker')
def picker():
    return "Hello"
