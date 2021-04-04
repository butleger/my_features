from models import *


context = {
    "headers": Header.query.all(),
}

class IndexView:
    def index():
        return render_template('common/rules.html', **context)

@app.route('/common/rules')
def rules():
    return render_template("common/rules.html", **context)

@app.route('/auth/home')
def home():
    return render_template("auth/home.html", **context)


@app.route('/auth/login', methods=['GET', 'POST'])
def login():
    return render_template("auth/login.html", **context, form=LoginForm())

@app.route('/auth/create_article', methods=['GET', 'POST'])
def create_article():
    if request.method == 'POST':
        print('title = ' + request.form.get('title'))
        print('article = ' + request.form.get('article'))
    return render_template("auth/create_article.html", **context, form=CreateArticleForm())

@app.route("/articles/picker")
def article_picker():
    return render_template("articles/picker.html", **context)


@app.route("/articles/<article_name>", methods = ['GET', 'POST'])
def article(article_name):
    if request.method == 'POST':
        print('comment = ' + request.form.get('comment'))
    return render_template("articles/article.html", **context, form=ArticleCommentForm())


@app.route("/forum/picker")
def forum_picker():
    return render_template("forum/picker.html", **context)


@app.route("/forum/<conversation_name>", methods = ['GET', 'POST'])
def conversation(conversation_name):
    if request.method == 'POST':
        print('message = ' + request.form.get('message'))
    return render_template("forum/conversation.html", **context, form=ForumCommentForm())


@app.errorhandler(404)
def error_404(error):
    return render_template('errors/404.html', **context)
