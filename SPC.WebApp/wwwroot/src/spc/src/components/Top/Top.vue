<template>
  <div>
    <el-header>
      <el-col :span="12">
        <div class="grid-content bg-purple topLeft">
          <img src="@/assets/images/logo.png" class="logo" alt="logo" />
          <span class="logo_content">DMAIC</span>
        </div>
      </el-col>
      <el-col :span="12">
        <div class="grid-content bg-purple-light topRight">
          <div class="grid-mar">
            <i class="el-icon-service"></i>
            <span></span>
          </div>
          <div class="grid-mar">
            <span class="user">{{currentUser.userName}}</span>
          </div>
          <div class="grid-mar signout">
            <span class="signout_exit" @click="open">Exit</span>
          </div>
        </div>
      </el-col>
    </el-header>
  </div>
</template>
<script>
import { mapGetters, mapActions } from "vuex";
export default {
  name: "Top",
  data() {
    return {
      dialogVisible: false //点击退出
    };
  },
  computed: {
    ...mapGetters("TopStore", [
      "fullscreen",
      "collapsed",
      "nickname",
      "defaultActiveIndex"
    ]),
    ...mapGetters("UserStore", ["currentUser"])
  },
  methods: {
    ...mapActions("TopStore", ["handleFullScreen", "handleSelect"]),
    open() {
      let that = this;
      this.$confirm("确认退出吗?", "提示", {
        confirmButtonClass: "el-button--warning"
      })
        .then(() => {
          //确认
          localStorage.clear();
          that.$router.replace("/login"); //用go刷新;
        })
        .catch(() => {});
    }
  }
};
</script>
<style scoped>
/* 文档写法 */
.el-header {
  background-color: #2673ff;
  color: #fff;
  border-bottom: 1px solid #d9d9d9;
  line-height: 60px;
  height: 60px;
}
.el-row {
  margin-bottom: 20px;
}
.el-row last-child {
  margin-bottom: 0;
}
.el-col {
  border-radius: 4px;
}
.grid-content {
  border-radius: 4px;
  min-height: 36px;
}
.urgent_img {
  vertical-align: middle;
}
.item {
  margin-right: 25px;
}
.el-button {
  width: 30px;
  height: 30px;
}
/* 自定义 */
.topLeft,
.topRight {
  flex-direction: row;
  display: flex;
  align-items: center;
}
.topRight {
  float: right;
}
/* 左边logo */
.logo {
  margin-right: 10px;
}
.logo_content {
  font-size: 19px;
  font-family: Avenir95-Black;
  font-weight: 500;
  color: rgba(255, 255, 255, 1);
}
/* 退出按钮 */
.signout {
  width: 40px;
  height: 40px;
  background: rgba(0, 91, 255, 1);
  border-radius: 20px;
  line-height: 35px;
  text-align: center;
}
.signout_exit {
  width: 27px;
  height: 21px;
  font-size: 15px;
  font-family: PingFangSC-Semibold;
  color: rgba(255, 255, 255, 1);
  line-height: 21px;
  cursor: pointer;
}
.grid-mar {
  margin-right: 23px;
}
/* 登陆人 */
.user {
  width: 201px;
  height: 17px;
  font-size: 18px;
  font-family: FZHTJW--GB1-0;
  font-weight: normal;
  color: rgba(255, 255, 255, 1);
  line-height: 21px;
}
.user_type {
  width: 144px;
  height: 18px;
  font-size: 17px;
  font-family: FZHTJW--GB1-0;
  font-weight: normal;
  color: #86abfe;
  line-height: 21px;
}
</style>
