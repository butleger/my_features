from base.models import Header
from flask import render_template, request


class BaseController:
    base_context = {
        "headers": Header.query.all(),
    }
    context = None
    template = None
    status=200
    

    @classmethod
    def setup(cls):
        return


    @classmethod
    def GET(cls):
        context = cls.get_context()
        if cls.template is None:
             raise Exception("You should specify the template!")
        return render_template(cls.template, **context), cls.status


    
    @classmethod
    def get_context(cls):
        if cls.context is not None:
            cls.base_context.update(cls.context)
        return cls.base_context 


    @classmethod
    def get_view(cls):
        def view(*args, **kwargs):
            cls.setup()
            
            if request.method == "POST":
                if hasattr(cls,"POST"):
                    return cls.POST()
                else :
                    return cls.GET()
            elif request.method == "GET":
                return cls.GET()
            else :
                return cls.GET()

        return view

    
    @classmethod
    def get_response(cls, *args, **kwargs):
        view = cls.get_view()
        return view(*args, **kwargs)