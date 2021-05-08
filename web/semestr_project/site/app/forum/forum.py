from flask import Blueprint, render_template, abort
from forum.controllers import ForumPickerController, ConversationController

forum = Blueprint("forum", __name__)


@forum.route('/')
def default_wrapper():
    return ForumPickerController.get_response()


@forum.route('/picker')
def picker_wrapper():
    return ForumPickerController.get_response()


@forum.route('/<conversation_name>')
def conversation_wrapper(conversation_name):
    return ConversationController.get_response(conversation_name)
