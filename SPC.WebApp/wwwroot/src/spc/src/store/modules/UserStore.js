import User from '../../model/User'
import {BaseActions, BaseGetters, BaseMutations, BaseState} from "./BaseStore";
import MutationTypes from "@/store/MutationTypes";
/**
 * 状态类
 */
class UserState extends  BaseState {

   constructor() {
     super(new User());
     let types=JSON.parse(localStorage.getItem("role"));
     if(types!=null)
     this.typeoptions.push(...types);
   }

  /**
   * 当前用户信息  用户名，用户id，所属角色，菜单权限，所属域权限，所属功能权限
   * @type {{roles: Array, permission: Array, userName: string, menu: Array, userId: string, workCenter: Array}}
   */
   currentUser={
     userName:""||localStorage.getItem('UserName'),
     userId:""||localStorage.getItem('UserId'),
     token:"",
     roles:[]||localStorage.getItem("role"),
     menu:[],
     workCenter:[],
     permission: {
       sys_menu_btn_add:true,
       sys_menu_btn_edit:true,
       sys_menu_btn_del:true
     }
   };
  /**
   * 用户类型数据字典
   * @type {*[]}
   */
  typeoptions =[];
  /**
   * 用户查询的过滤条件
   * @type {{UserName: string}}
   */
   filter = { Keyword: '' };
  /**
   * 编辑用户Form验证规则
   */
   editFormRules =
    {
      userName: [
        {required: true, message: '请输入真实姓名', trigger: 'blur'}
      ],
      userCode: [
        {required: true, message: '请输入用户名', trigger: 'blur'}
      ],
      eMail: [
        {required: true, message: '请输入电子邮件', trigger: 'blur'}
      ], mobilePhone: [
        {required: true, message: '请输入联系电话', trigger: 'blur'}
      ]
      ,roleId: [
       {required: true, message: '请选择用户角色', trigger: 'blur'}
    ]
    };
}
/**
 * get类
 */
class UserGetters extends  BaseGetters {
    typeoptions=state=>state.typeoptions;
    currentUser=state=>state.currentUser;
}

/**
 * action 类
 */
export class UserActions extends  BaseActions{

}
/**
 * mutaions
 */
class UserMutations extends BaseMutations {
  [MutationTypes.SET_CURUSERNAME]=(state,username)=>{
    state.currentUser.userName=username;
  };
  [MutationTypes.SET_CURUSERID]=(state,userid)=>{
    state.currentUser.userId=userid;
  };
  [MutationTypes.SET_CURMENU]=(state,{menu})=>{
    state.currentUser.menu=menu;
  };
  [MutationTypes.SET_CURWORKCENTER]=(state,{workcenter})=>{
    state.currentUser.workCenter=workcenter;
  };
  [MutationTypes.SET_CURROLES]=(state,{roles})=>{
    state.currentUser.roles=roles;
  };
  [MutationTypes.SET_CURPERMISSION]=(state,{permission})=>{
    state.currentUser.permission=permission;
  };
  [MutationTypes.SET_TOKEN]=(state,token)=>{
    state.currentUser.token=token;
  };
}
export  default
{
  namespaced: true,
  state:new UserState(),
  getters:new UserGetters(),
  mutations:new UserMutations(),
  actions:new UserActions()
};
