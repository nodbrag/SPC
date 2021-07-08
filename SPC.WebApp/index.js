import Vue from 'vue'
import Router from 'vue-router'
import  routes from './routers.js'
Vue.use(Router);
 let router =new Router({
  mode:'history',
  routes:routes
});
router.beforeEach((to, from, next) => {
  // console.log('to:' + to.path)
  if (to.path.startsWith('/login')) {
    window.localStorage.removeItem('token');
    next()
  } else {
    let user = JSON.parse(window.localStorage.getItem('token'));
    if (!user) {
      next({path: '/login'})
    } else {
      next()
    }
  }
});

export default router
