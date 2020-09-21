from django.contrib import admin
from django.urls import include
from django.urls import path
from . import views

app_name = 'accounts'
urlpatterns = [
    path('registration/', views.registrate, name='register_user'),
    path('registration/complete', views.MySuccessRegistrationView.as_view(), name='success_registration'),
    path('login/', views.MyLoginView.as_view(), name='login'),
    path('logout/', views.MyLogoutView.as_view(), name='logout'),
    path('success_login/', views.MySuccessLoginView.as_view(), name='success_login'),
]
