from flask import render_template, request
from base.models import Header
from forum.forms import ForumCommentForm

context = {
    'headers': Header.query.all()
} 

def forum_picker():
    return render_template("forum/picker.html", **context)


def conversation(conversation_name):
    if request.method == 'POST':
        print('message = ' + request.form.get('message'))
    return render_template("forum/conversation.html", **context, form=ForumCommentForm())
