from flask_wtf import FlaskForm
from wtforms.validators import DataRequired, Required
from wtforms import StringField, PasswordField, SubmitField, TextAreaField


class ForumCommentForm(FlaskForm):
    message = TextAreaField('Shit', render_kw={
                                        'placeholder': 'Your message...',
                                        'class': 'text_input',
                                        'rows': 8
                                        })
    submit = SubmitField('Send', render_kw={'class':'submit_input'})
