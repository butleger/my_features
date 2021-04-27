from base.models import User


class UserLogin:
    def from_db(self, name, password):
        if name is None or password is None:
            return None
        self.__user = User.query.filter_by(nickname=name, password_hash=password).first()
        if self.__user is None:
            return None
        else :
            return self


    def from_db_by_id(self, user_id):
        if user_id is None:
            return None
        self.__user = User.query.filter_by(id=user_id).first()
        if self.__user is None:
            return None
        else :
            return self


    def create(self, user):
        self.__user = user
        return self


    def is_authenticated(self):
        return True

    
    def is_active(self):
        return True

    
    def is_anonymous(self):
        return False

    
    def get_id(self):
        return self.__user.id