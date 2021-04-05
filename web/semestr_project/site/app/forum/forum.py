from flask import Blueprint, render_template, abort
from forum.views import *

forum = Blueprint("forum", __name__)


@forum.route('/')
def default_wrapper():
    return forum_picker()

@forum.route('/picker')
def picker_wrapper():
    return forum_picker()


@forum.route('/conversation/<conversation_name>')
def conversation_wrapper(conversation_name):
    return conversation(conversation_name)
