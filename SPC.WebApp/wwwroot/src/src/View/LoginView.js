import { mapGetters,mapActions } from "vuex";
import AuthApi from "../api/AuthApi";
let api=new AuthApi();
export  default  class LoginView{
  /**
   * 名称
   * @type {string}
   */
  name='login';
  /**
   * 计算属性
   */
  computed={
    ...mapGetters('AuthStore',['account','editFormRules']),
    ...mapGetters('CommonStore',['loading'])
  };
  /**
   * 方法
   */
  methods= {
    ...mapActions('AuthStore',['login']),
    loginGo:function () {
      this.$refs.AccountFrom.validate((valid) => {
        if (valid) {
           this.login(api).then((data)=>{
             this.$router.push({path: '/spcAnalysis'});
           }).catch((error)=>{
             this.$message.error({showClose: true, message:error || '登录失败', duration: 2000});
           })
        }});
    }
  };
}
