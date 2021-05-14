class Config:
    SEND_FILE_MAX_AGE_DEFAULT = 0

    SECRET_KEY = 'shitty asshole'

    #DATABASE_PATH = '/home/fedr/python/semestr_project/project/site/app/flsite.db'

    #MONGOALCHEMY_DATABASE = "semestr_project"
    #SQLALCHEMY_DATABASE_URI = "sqlite:///" + DATABASE_PATH
    MYSQL_PASS  = "fedr"
    MYSQL_LOGIN = "fedr"
    MYSQL_HOST  = "127.0.0.1"
    DATABASE_NAME = "my_site"

    SQLALCHEMY_DATABASE_URI = f"mysql+pymysql://{MYSQL_LOGIN}:{MYSQL_PASS}@{MYSQL_HOST}/{DATABASE_NAME}"
    SQLALCHEMY_TRACK_MODIFICATIONS = False

config = Config
