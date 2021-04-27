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
    def setup(cls, *args, **kwargs):
        return


    @classmethod
    def GET(cls, *args, **kwargs):
        context = cls.get_context(*args, **kwargs)
        if cls.template is None:
             raise Exception("You should specify the template!")
        return render_template(cls.template, **context), cls.status


    
    @classmethod
    def get_context(cls, *args, **kwargs):
        if cls.context is not None:
            cls.base_context.update(cls.context)
        return cls.base_context 


    @classmethod
    def get_view(cls, *args, **kwargs):
        def view(*args, **kwargs):
            cls.setup()
            
            if request.method == "POST":
                if hasattr(cls,"POST"):
                    return cls.POST(*args, **kwargs)
                else :
                    return cls.GET(*args, **kwargs)
            elif request.method == "GET":
                return cls.GET(*args, **kwargs)
            else : # default method
                return cls.GET(*args, **kwargs)

        return view

    
    @classmethod
    def get_response(cls, *args, **kwargs):
        view = cls.get_view(*args, **kwargs)
        return view(*args, **kwargs)