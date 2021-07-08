import axios  from 'axios' //ajax异步请求插件
import NProgress from 'nprogress' // 进度条插件
import 'nprogress/nprogress.css'// 进度条插件样式
//基地址
let base = 'http://180.76.151.131:50027';  //接口代理地址参见：config/index.js中的proxyTable配置
//let base = 'http://localhost:50027';
NProgress.configure({ showSpinner: false })// NProgress Configuration
let msg = '服务器忙，请稍后再试';
//设置超时时间
axios.defaults.timeout = 600000;
//跨域请求，允许保存cookie
//axios.defaults.withCredentials = true;

//HTTPrequest请求拦截
axios.interceptors.request.use(config => {
  //进度条开始
  NProgress.start();
  if (window.localStorage.getItem("token") != null) {
    config.headers['Authorization'] = 'Bearer ' + JSON.parse(window.localStorage.getItem('token')).token;// 让每个请求携带Authorization
  }
  return config
}, error => {
  console.log('err' + error)// for debug
  return Promise.reject(error)
});
//HTTPresponse拦截
axios.interceptors.response.use(data => {
  NProgress.done();
  return data
}, error => {
  NProgress.done();
  return Promise.reject(error);
});

export const POST = (url, params) => {
  return axios.post(`${base}${url}`, params).then(res => res.data)
};

export const GET = (url, params) => {
  return axios.get(`${base}${url}`, {params: params}).then(res => res.data)
};

export const PUT = (url, params) => {
  return axios.put(`${base}${url}`, params).then(res => res.data)
};
export const DELETE = (url, params) => {
  return axios.delete(`${base}${url}`, {params: params}).then(res => res.data)
};
export const PATCH = (url, params) => {
  return axios.patch(`${base}${url}`, params).then(res => res.data)
};

