from django.urls import path
from .views import *

app_name = 'accounts'
urlpatterns = [
    path('registration/', registrate, name='register_user'),
    path('registration/complete', MySuccessRegistrationView.as_view(), name='success_registration'),
    path('login/', MyLoginView.as_view(), name='login'),
    path('logout/', MyLogoutView.as_view(), name='logout'),
    path('success_login/', MySuccessLoginView.as_view(), name='success_login'),
    path('new_login/', MyLoginTestView.as_view(), name='test'),
]
