from flask_wtf import FlaskForm
from wtforms import StringField, PasswordField, SubmitField, TextAreaField
from wtforms.validators import DataRequired, Required


class ArticleCommentForm(FlaskForm):
    comment = TextAreaField('Shit', render_kw={
                                        'placeholder': 'Your comment...',
                                        'class': 'text_input',
                                        'rows': 8
                                        })
    submit = SubmitField('Send', render_kw={'class':'submit_input'})


class CreateArticleForm(FlaskForm):
    title = StringField('Title:', render_kw={
                                    'class':"title_input",
                                    'id': "create_article_title",
                                    'placeholder': "Your title..."
                                    })
    article = TextAreaField('Article:', render_kw={
                                        'placeholder': 'Your article...',
                                        'class': 'article_input',
                                        'id':"create_article_text",
                                        'rows': 20
                                        })
    submit = SubmitField('Send article', render_kw={'class': 'submit_input'})


class LoginForm(FlaskForm):
    login = StringField('login',
                        validators=[ DataRequired() ],
                        render_kw = {'placeholder': 'password',
                                     'class': 'login_input'
                                     })
    password = PasswordField('password', render_kw = {
                                        'placeholder': 'password',
                                        'class': 'password_input'
                                        },
                            validators=[
                                        DataRequired(),
                                        Required()
                                        ])
    submit = SubmitField("LogIn",
                         render_kw={'class': 'submit_input'})


class ForumCommentForm(FlaskForm):
    message = TextAreaField('Shit', render_kw={
                                        'placeholder': 'Your message...',
                                        'class': 'text_input',
                                        'rows': 8
                                        })
    submit = SubmitField('Send', render_kw={'class':'submit_input'})
