from flask import render_template
from base.models import Header
from base.controllers import BaseController


class RulesController(BaseController):
    template = "common/rules.html"
