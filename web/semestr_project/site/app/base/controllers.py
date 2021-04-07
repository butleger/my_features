from base.models import Header
from flask import render_template


class BaseController:
    base_context = {
        "headers": Header.query.all(),
    }
    context = None
    template = None
    
    
    @classmethod
    def get_context(cls):
        if cls.context is not None:
            cls.base_context.update(cls.context)
        return cls.base_context 


    @classmethod
    def get_view(cls):
        context = cls.get_context()
        def view(*args, **kwargs):
            print("args = " + str(args))
            print("kwargs = " + str(kwargs))
            if cls.template is None:
                raise Exception("You should specify the template!")
            return render_template(cls.template, **context)
        return view

    
    @classmethod
    def get_response(cls, *args, **kwargs):
        view = cls.get_view()
        return view(*args, **kwargs)