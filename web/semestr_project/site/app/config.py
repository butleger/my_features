class Config:
    SEND_FILE_MAX_AGE_DEFAULT = 0

    SECRET_KEY = 'shitty asshole'

    DATABASE_PATH = '/home/fedr/python/semestr_project/project/site/app/flsite.db'

    SQLALCHEMY_DATABASE_URI = "sqlite:///" + DATABASE_PATH
    SQLALCHEMY_TRACK_MODIFICATIONS = False

config = Config
