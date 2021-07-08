<template>
  <div class="Login">
      <div class="Login_left">
        <div  class="Login_img">
          <img src="@/assets/images/logo.png" class="logo" alt="logo" />
          <span class="logo_content">DMAIC</span>
        </div>
        <el-form ref="AccountFrom" :model="account" :rules="editFormRules" label-position="left" label-width="0px" class="demo-ruleForm login-container">
          <h3 class="title">登陆系统</h3>
          <el-form-item prop="userCode">
            <span class="Login_span">账号</span>
            <el-input type="text" v-model="account.userCode" auto-complete="off" placeholder="账号"></el-input>
          </el-form-item>
          <el-form-item prop="pwd">
            <span class="Login_span">密码</span>
            <el-input type="password" v-model="account.password" auto-complete="off" placeholder="密码" @keyup.enter.native="loginGo"></el-input>
          </el-form-item>
          <!--<el-checkbox v-model="checked" checked class="remember">记住密码</el-checkbox>-->
          <el-form-item style="width:100%;">
            <el-button type="primary" style="width:100%;height: 67px; background: rgba(46,91,255,1); border-radius: 5px;" @click.native.prevent="loginGo" :loading="loading">登录</el-button>
          </el-form-item>
          <el-form-item prop="pwd">
            <span class="Login_span">忘记密码请向管理员申请修改</span>
          </el-form-item>
        </el-form>
      </div>
      <div class="Login_right"> </div>
  </div>
</template>
<script>
import LoginView from "../../View/LoginView";
export default  new LoginView();
</script>
<style>
  body {
    background: #fff;
  }
</style>
<style lang="stylus">
  /**/
  .Login{
    width:100%;
    float: left;
    .Login_left{
      width:50%;
      float: left;
      font-size: 45px;
      font-family: PingFangSC-Semibold;
      font-weight: 600;
      color: rgba(46,56,77,1);
      line-height: 43px;
      .el-form{
        width: 50%;
        margin: auto;
        margin-top: 20%;
      }
    }
    .Login_right{
      width:50%;
      height: 937px;
      float: left;
      background-image: url('./images/Image.jpg');
      background-size: 100% 100%;
    }
    .Login_img{
      margin: auto;
      margin-left: 25%;
      span{
        width: 291px;
        height: 27px;
        font-size: 25px;
        font-family: Avenir95-Black;
        font-weight: 900;
        color: rgba(46,56,77,1);
        line-height: 29%;
      }
    }
    .Login_span{
      font-size: 16px;
      font-family: PingFangSC-Regular;
      font-weight: 400;
      color: rgba(176,186,201,1);
      line-height: 23px;
      letter-spacing: 1px;
    }
    .el-input__inner{
      height: 53px;
      background: rgba(224,231,255,0.2);
      border-radius: 7px;
      border: 1px solid rgba(224,231,255,1)
    }
  }
  .login-container {
    .title {
      margin: 0px auto 80px auto;
      font-size: 45px;
      font-family: PingFangSC-Semibold;
      font-weight: 600;
      color: rgba(46,56,77,1);
      text-align: left;
    }
  }
</style>
