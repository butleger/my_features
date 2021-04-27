from flask import render_template, request
from articles.forms import ArticleCommentForm
from base.models import Header, Article
from base.controllers import BaseController



class ArticlePickerController(BaseController):
    template = "articles/picker.html"


class ArticleController(BaseController):
    template = "articles/article.html"


    @classmethod
    def get_view(cls):
        def view(*args, **kwargs):
            context = cls.get_context()
            article_name = args[0]
            print("article name = " + str(article_name))
            if request.method == 'POST':
                print('comment = ' + request.form.get('comment'))
            return render_template(cls.template, **context, form=ArticleCommentForm())
        return view
