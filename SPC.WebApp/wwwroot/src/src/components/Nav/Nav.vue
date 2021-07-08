<template>
  <div class="navbox">
    <el-row class="tac">
      <el-col :span="24">
        <!--导航菜单-->

        <el-menu :default-active="$route.path"
                 class="el-menu-vertical-demo"
                 @open="handleOpen"
                 @close="handleClose"
                 text-color="#7B95BC"
                 unique-opened>
          <!--<router-link to="/home/index" :class="{active:'/home/index' === $route.path}">
            <el-menu-item index="1">
              <svg-icon icon-class="setting" />
              <span>首页</span>
            </el-menu-item>
          </router-link>-->
          <router-link to="/spcAnalysis" :class="{active:$route.path.includes('/spcAnalysis')}">
            <el-menu-item index="3">
              <svg-icon icon-class="analyze" />
              <span>SPC分析</span>
            </el-menu-item>
          </router-link>
          <el-submenu index="1">
            <template slot="title" :class="{active:$route.path.includes('/dimension' || '/appearance' || '/display')}">
              <svg-icon icon-class="setting" />
              <span>数据分类</span>
            </template>
            <router-link to="/dimension" :class="{active:$route.path.includes('/dimension')}"><el-menu-item index="1-1">测量数据</el-menu-item></router-link>
            <router-link to="/appearance" :class="{active:$route.path.includes('/appearance')}"><el-menu-item index="1-2">视觉数据</el-menu-item></router-link>
            <router-link to="/discrete" :class="{active:$route.path.includes('/discrete')}"><el-menu-item index="1-3">离散数据</el-menu-item></router-link>
          </el-submenu>
          <el-submenu index="2">
            <template slot="title">
              <svg-icon icon-class="class" />
              <span>基础档案</span>
            </template>
            <router-link to="/equipment" :class="{active:$route.path.includes('/equipment')}"><el-menu-item index="2-2">设备管理</el-menu-item></router-link>
            <router-link to="/inject" :class="{active:$route.path.includes('/inject')}"><el-menu-item index="2-1">产品管理</el-menu-item></router-link>
            <router-link to="/causal" :class="{active:$route.path.includes('/causal')}"><el-menu-item index="2-4">工序管理</el-menu-item></router-link>
            <router-link to="/plastic" :class="{active:$route.path.includes('/plastic')}"><el-menu-item index="2-3">缺陷档案</el-menu-item></router-link>
            <router-link to="/parameter" :class="{active:$route.path.includes('/parameter')}"><el-menu-item index="2-3">参数管理</el-menu-item></router-link>
            <router-link to="/setting" :class="{active:$route.path.includes('/setting')}"><el-menu-item index="2-5">系统设置</el-menu-item></router-link>
            <!--<router-link to="/user" :class="{active:$route.path.includes('/user')}"><el-menu-item index="2-5">用户管理</el-menu-item></router-link>-->
          </el-submenu>

        </el-menu>
      </el-col>
    </el-row>
  </div>
</template>
<script>
  export default {
    methods: {
      handleOpen(key, keyPath) {
        console.log(key, keyPath);
      },
      handleClose(key, keyPath) {
        console.log(key, keyPath);
      }
    }
  }
</script>
<style>
  .navbox {
    width: 250px;
    float: left;
    background-color: #FFF;
    height: calc(100vh - 60px);
    font-family: PingFangSC-Regular;
  }
  .navbox .el-menu{
    border-right:none;
  }
  .navbox .el-menu > li {
    display: inline-block;
    font-size: 15px;
    width: calc(100%);
  }
  .el-menu .el-submenu__title {
    color: #7B95BC !important;
    font-size: 15px;
    height:63px;
    line-height:63px;
  }
  .el-menu .el-menu-item{
    font-size: 15px;
    height:63px;
    line-height:63px;
  }
  .el-menu .el-submenu .el-menu-item{
    height:52px;
    line-height:52px;
  }
  .el-menu a.active li {
    background: #2673FF;
    color: #fff !important;
    font-family: '方正大黑简体';
  }
  .el-menu a.active li .svg-icon{
    color: #003BA5 !important
  }
  .el-icon-arrow-down:before {
    content: none
  }
  .el-menu .el-submenu.is-opened .el-submenu__title{
    background: #2673FF;
    color: #fff !important;
    font-family: '方正大黑简体';
  }
  .el-menu .el-submenu.is-opened .el-submenu__title .svg-icon{
    color: #003BA5 !important
  }
  .el-menu .el-submenu.is-opened {
    background: rgba(46,91,255,0.1);
  }
  .el-menu .el-submenu.is-opened a.active li{
    border-left: 3px solid #2E5BFF;
    background: rgba(46,91,255,0.1262);
    color: #2673FF !important;
    font-family: PingFangSC-Regular;
  }
  .el-menu .el-submenu .el-menu-item {
    font-size: 13px;
    background: rgba(46,91,255,0.1);
    color: #B0BAC9;
    padding-left: 75px !important
  }
</style>
