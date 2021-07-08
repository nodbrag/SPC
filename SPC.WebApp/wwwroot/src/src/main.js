// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import router from './router/index'
import  store from './store/index'
import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import './common/common.stylus'
import App from './App'
import '@/icons' // icon
import echarts from 'echarts'
import  moment from 'moment'
Vue.config.productionTip = false
Vue.use(ElementUI);
Vue.prototype.$echarts = echarts;
// 定义过滤器
Vue.filter('dateString', function (value, format='YYYY-MM-DD HH:mm:ss') {
  return moment(value).format(format);
});
/* eslint-disable no-new */
new Vue({
  el: '#app',
  render: h => h(App),
  router,
  store
})

