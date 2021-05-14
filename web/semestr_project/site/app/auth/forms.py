from flask_wtf import FlaskForm
from wtforms.validators import DataRequired, Required
from wtforms import StringField, PasswordField, SubmitField, TextAreaField


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
                        render_kw = {'placeholder': 'login',
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


class CreateUserForm(FlaskForm):
    nickname = StringField('nickname', render_kw={
        'placeholder': 'nickname',
        'class': 'nickname_input',
    })
    password = PasswordField('password', render_kw={
        'placeholder': 'password',
        'class': 'password_input'
    })
    image_url = StringField('image_url', render_kw={
        'placeholder': 'url to image',
        'class': 'image_url_input'
    })
    email = StringField('email', render_kw={
        'placeholder': '****@***.***',
        'class': 'email_input',
    })
    about = TextAreaField('about', render_kw={
        'placeholder': 'big info about user',
        'class': 'about_input',
        'rows': 20,
    })
    footer = TextAreaField('footer', render_kw={
        'placeholder': 'some unnecesary information',
        'class': 'footer_input',
        'rows': 20,
    }) 
    submit = SubmitField('Create', render_kw={
        'class': 'submit_input',
    })