from flask import render_template, request
from base.models import Header
from forum.forms import ForumCommentForm
from base.controllers import BaseController


class ForumPickerController(BaseController):
    template = "forum/picker.html"


class ConversationController(BaseController):
    template = "forum/conversation.html"

    @classmethod
    def get_view(cls, *args, **kwargs):
        def view(*args, **kwargs):
            context = cls.get_context()
            conversation_name = args[0]
            print("conversation name = " + str(conversation_name))
            if request.method == 'POST':
                print('message = ' + request.form.get('message'))
            return render_template(cls.template, **context, form=ForumCommentForm())
        return view

