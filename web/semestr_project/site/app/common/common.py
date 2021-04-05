from flask import Blueprint, render_template, abort
from common.views import *


common = Blueprint("common", __name__)


@common.route('/rules')
def rules_wrapper():
    return rules()