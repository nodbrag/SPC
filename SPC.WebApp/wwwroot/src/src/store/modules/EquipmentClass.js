import EquipmentClass from '../../model/EquipmentClass'
import {BaseActions, BaseGetters, BaseMutations, BaseState} from "./BaseStore";
import MutationTypes from "@/store/MutationTypes";
/**
 * 状态类
 */
class EquipmentClassState extends  BaseState {

   constructor() {
     super(new EquipmentClass());
     let types=JSON.parse(localStorage.getItem("role"));
     if(types!=null)
     this.typeoptions.push(...types);
   }

  /**
   * 当前用户信息  用户名，用户id，所属角色，菜单权限，所属域权限，所属功能权限
   * @type {{roles: Array, permission: Array, EquipmentClassName: string, menu: Array, EquipmentClassId: string, workCenter: Array}}
   */
   currentEquipmentClass={
     EquipmentClassName:""||localStorage.getItem('EquipmentClassName'),
     EquipmentClassId:""||localStorage.getItem('EquipmentClassId'),
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
   * @type {{EquipmentClassName: string}}
   */
   filter = { Keyword: '' };
  /**
   * 编辑用户Form验证规则
   */
   editFormRules =
    {
      EquipmentClassName: [
        {required: true, message: '请输入真实姓名', trigger: 'blur'}
      ],
      EquipmentClassCode: [
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
class EquipmentClassGetters extends  BaseGetters {
    typeoptions=state=>state.typeoptions;
    currentEquipmentClass=state=>state.currentEquipmentClass;
}

/**
 * action 类
 */
export class EquipmentClassActions extends  BaseActions{

}
/**
 * mutaions
 */
class EquipmentClassMutations extends BaseMutations {
  [MutationTypes.SET_CUREquipmentClassNAME]=(state,EquipmentClassname)=>{
    state.currentEquipmentClass.EquipmentClassName=EquipmentClassname;
  };
  [MutationTypes.SET_CUREquipmentClassID]=(state,EquipmentClassid)=>{
    state.currentEquipmentClass.EquipmentClassId=EquipmentClassid;
  };
  [MutationTypes.SET_CURMENU]=(state,{menu})=>{
    state.currentEquipmentClass.menu=menu;
  };
  [MutationTypes.SET_CURWORKCENTER]=(state,{workcenter})=>{
    state.currentEquipmentClass.workCenter=workcenter;
  };
  [MutationTypes.SET_CURROLES]=(state,{roles})=>{
    state.currentEquipmentClass.roles=roles;
  };
  [MutationTypes.SET_CURPERMISSION]=(state,{permission})=>{
    state.currentEquipmentClass.permission=permission;
  };
  [MutationTypes.SET_TOKEN]=(state,token)=>{
    state.currentEquipmentClass.token=token;
  };
}
export  default
{
  namespaced: true,
  state:new EquipmentClassState(),
  getters:new EquipmentClassGetters(),
  mutations:new EquipmentClassMutations(),
  actions:new EquipmentClassActions()
};
