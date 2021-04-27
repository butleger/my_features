from extensions import db as DB
import datetime


class Header(DB.Model):
    __tablename__ = "headers"
    __table_args__ = {'extend_existing': True}
    id = DB.Column(DB.Integer(), primary_key=True)
    title = DB.Column(DB.String(255), nullable=False)
    url = DB.Column(DB.String(255), nullable=False)

    def __repr__(self):
        return f"{self.id} {self.title} {self.url}"


class User(DB.Model):
    __tablename__ = "users"
    __table_args__ = {'extend_existing': True}
    id = DB.Column(DB.Integer(), primary_key=True)
    nickname = DB.Column(DB.String(255), unique=True, nullable=False)
    password_hash = DB.Column(DB.String(512), nullable=False)
    email = DB.Column(DB.String(255), nullable=False)
    image_url = DB.Column(DB.String(255), nullable=False)
    footer_text = DB.Column(DB.Text())
    about = DB.Column(DB.Text())
    registration_date = DB.Column(DB.DateTime(),default=datetime.datetime.now(),
                                                onupdate=datetime.datetime.now(),
                                                nullable=False)

    def __repr__(self):
        return f"{self.nickname} with email: {self.email}"

    # This is required for flask-login
    def is_authenticated(self):
        return True

    
    def is_active(self):
        return True

    
    def is_anonymous(self):
        return False

    
    def get_id(self):
        return self.id



class UserPermission(DB.Model):
    __tablename__ = "user_permissions"
    __table_args__ = {"extend_existing": True}
    id = DB.Column(DB.Integer(), primary_key=True)
    user_id = DB.Column(DB.Integer(), DB.ForeignKey("users.id"))


class Article(DB.Model):
    __tablename__ = "articles"
    __table_args__ = {'extend_existing': True}
    id = DB.Column(DB.Integer(), primary_key=True)
    title = DB.Column(DB.String(255), nullable=False)
    user_id = DB.Column(DB.Integer(), DB.ForeignKey("users.id"))
    date = DB.Column(DB.DateTime(), default=datetime.datetime.now(), onupdate=datetime.datetime.now(), nullable=False)
    text = DB.Column(DB.Text(), nullable=False)

    def __repr__(self):
        return f"Article \"{self.title}\" ..."


class ArticleComment(DB.Model):
    __tablename__ = "article_comments"
    __table_args__ = {'extend_existing': True}
    id = DB.Column(DB.Integer(), primary_key=True)
    text = DB.Column(DB.Text(), nullable=False)
    user_id = DB.Column(DB.Integer(), DB.ForeignKey("users.id"))
    article_id = DB.Column(DB.Integer(), DB.ForeignKey("articles.id"))
    date = DB.Column(DB.DateTime(), default=datetime.datetime.now(),
                                    onupdate=datetime.datetime.now(),
                                    nullable=False)

    def __repr__(self):
        return f"ArticleComment with author_id: {user_id}, article_id: {article_id}, text: {text}"


class Forum(DB.Model):
    __tablename__ = "forums"
    __table_args__ = {'extend_existing': True}
    id = DB.Column(DB.Integer(), primary_key=True)
    title = DB.Column(DB.String(255), nullable=False)
    creator_id = DB.Column(DB.Integer(), DB.ForeignKey("users.id"))
    date = DB.Column(DB.DateTime(), default=datetime.datetime.now(),
                                    onupdate=datetime.datetime.now(),
                                    nullable=False)

    def __repr__(self):
        return f"forum called {title}"


class ForumComment(DB.Model):
    __tablename__ = "forum_comments"
    __table_args__ = {'extend_existing': True}
    id = DB.Column(DB.Integer(), primary_key=True)
    text = DB.Column(DB.Text(), nullable=False)
    user_id = DB.Column(DB.Integer(), DB.ForeignKey("users.id"))
    forum_id = DB.Column(DB.Integer(), DB.ForeignKey("articles.id"))
    date = DB.Column(DB.DateTime(), default=datetime.datetime.now(),
                                    onupdate=datetime.datetime.now(),
                                    nullable=False)

    def __repr__(self):
        return f"ArticleComment with author_id: {user_id}, article_id: {article_id}, text: {text}"
