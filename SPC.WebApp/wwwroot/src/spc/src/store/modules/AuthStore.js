import MutationTypes from "@/store/MutationTypes";
/**
 * 角色状态类
 */
class AuthState  {
  account= {
    userCode: '',
    password: ''
  };
  editFormRules={
    userCode: [
      {required: true, message: '请输入账号', trigger: 'blur'},
    ],
    password: [
      {required: true, message: '请输入密码', trigger: 'blur'},
    ]
  }
}
/**
 * action 类
 */
class AuthActions
{
   login=({commit,state, rootGetters },api)=>{
     let parms = Object.assign({}, state.account);
     commit('CommonStore/' + MutationTypes.SET_LOADING, true, {root: true});
     let commonDictionaryApi= rootGetters['CommonDictionaryStore/api'];
     return new Promise((resolve, reject) => {
       api.getToken(parms).then(data => {
         let success = data.success;
         if (success){
           localStorage.setItem('token', JSON.stringify(data.result));
           let username=data.result.user.userName;
           let userid=data.result.user.userId;
           let token=data.result.token;
          // let menu=data.result.menu;
           localStorage.setItem("UserName",username);
           localStorage.setItem("UserId",userid);
           //更新公共的信息
           commit('TopStore/'+MutationTypes.SET_NICKNAME,username,{root:true});
           //设置当前用户名
           commit('UserStore/'+MutationTypes.SET_CURUSERNAME,username,{root:true});
           //设置当前用户编号
           commit('UserStore/'+MutationTypes.SET_CURUSERID,userid,{root:true});
           //设置当前用户token
           commit('UserStore/'+MutationTypes.SET_TOKEN,token,{root:true});
           //设置菜单授权
           //commit('UserStore/'+MutationTypes.SET_CURMENU,{menu},{root:true});
           //初始化数据
          commonDictionaryApi.getCommonDictionry({}).then(dic=>{
               for(let [key,value] of Object.entries(dic.result)) {
                 window.localStorage.setItem(key,JSON.stringify(value));
               }
                //let menus=dic.result.menu;
                //commit('CommonDictionaryStore/'+MutationTypes.SET_MENU,{menus},{root:true});
            let product= localStorage.getItem("product");
            if(product!=null&&product!=undefined) {
              let val=JSON.parse(localStorage.getItem("product"));
              commit('CommonDictionaryStore/'+MutationTypes.ProductOptions,{val},{root:true});
              val=JSON.parse(localStorage.getItem("equipment"));
              commit('CommonDictionaryStore/'+MutationTypes.EquipmentOptions,{val},{root:true});
            }
            resolve(data);
           });
         } else {
           reject(data.message)
         }
         commit('CommonStore/' + MutationTypes.SET_LOADING, false, {root: true});
       }).catch(error=>{
         reject(error);
       })
     });
   }
}
/**
 * getters 类
 */
class AuthGetters  {
  account=state=>state.account;
  editFormRules=state=>state.editFormRules;
}
/**
 * mutaions
 */
class AuthMutations {

}
export  default
{
  namespaced: true,
  state:new AuthState(),
  getters:new AuthGetters(),
  mutations:new AuthMutations(),
  actions:new AuthActions()
};
