from flask import Blueprint, render_template, abort
from common.controllers import RulesController


common = Blueprint("common", __name__)


@common.route('/rules')
def rules_wrapper():
    return RulesController.get_response()