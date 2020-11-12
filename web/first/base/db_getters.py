from django.core.exceptions import MultipleObjectsReturned, ObjectDoesNotExist
from .exceptions import *
from articles.models import *

def getMenu():
    try:
        print(10*"=" + "MENU" + 10*"=")
        menu = MainMenuElementModel.objects.all()
    except ObjectDoesNotExist:
        raise CantGetMenu()
    except BaseException:
        raise Shit()
    else:
        return menu


def getFooter():
    try:
        print(10*"=" + "FOOTER" + 10*"=")
        result = {}
        footerBlocks = FooterBlockModel.objects.all()
        allFooterContent = FooterContentModel.objects.all()
        size = footerBlocks.count()
        i = 0
        while i < size:
            footerContent = allFooterContent.filter(footerBlock=footerBlocks[i])
            footerElement = {'name': footerBlocks[i].name,
                             'content': footerContent}
            result[i] = footerElement
            i += 1
        return result
    except NameError:
        raise MyBad()
    except IndexError:
        raise NoFooter()
    except ObjectDoesNotExist:
        raise NoFooter()


def getSingleArticlesByNames(*articleNames):
    singleArticles = {}
    try:
        for name in articleNames:
            singleArticles[str(name)] = getSingleArticleByName(name)
    except MultipleObjectsReturned:
        raise ManySingleArticles()
    except ObjectDoesNotExist:
        raise NoSingleArticles()
    except:
        raise Shit()

def getSingleArticleByName(name):
    try:
        singleArticle = SingleArticleModel.objects.get(name=name)
    except MultipleObjectsReturned:
        raise ManySingleArticles()
    except ObjectDoesNotExist:
        raise NoSingleArticles()
    except:
        raise Shit()
    return singleArticle

#return dictionary of pairs {footerBlock, footerContent} where footerContent might be also dictionary


