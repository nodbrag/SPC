
import Appearance from "../../model/DefectItem";
import MutationTypes from "../MutationTypes";
import {BaseActions, BaseGetters, BaseMutations, BaseState} from "./BaseStore";
import Vue from 'vue';
let vue=new Vue();
/**
 * 角色状态类
 */
class AppearanceStore extends  BaseState {
  constructor()
  {
    super(new Appearance());
  }
  /**
   * 视觉数据列表变量
  */
  AppearanceDetailList=[];
}
/**
 * action 基类
 */
export class AppearanceActions extends  BaseActions{
  /**
   * 绑定视觉列表信息
   * @param commit
   * @param state
   * @param rootGetters
   */
  bindAppearanceInfos=({commit,state, rootGetters },parms)=>{
    commit('CommonStore/' + MutationTypes.SET_LOADING, true, {root: true});
    return new Promise((resolve, reject) => {
      // alert(JSON.stringify(state.api));
       state.api.GetAppearanceList(parms).then(data => {
        //    console.log(data);
        let success = data.success;
        if (success){
          let datas = data.result;
          let count=data.result.totalCount;
          commit(MutationTypes.SET_EDITAPPEARANCE, {datas});
          commit('CommonStore/' + MutationTypes.SET_TOTALCOUNT, count, {root: true});
          resolve(datas);
        } else {
          reject(data.message);
        }
        commit('CommonStore/' + MutationTypes.SET_LOADING, false, {root: true});
      }).catch(error=>{
        reject(error);
      })
    });
  };
}
/**
 * getters 基类
 */
class AppearanceGetters extends  BaseGetters {
  AppearanceDetailList=state => state.AppearanceDetailList;
}
/**
 * mutaions
 */
class AppearanceMutations extends BaseMutations {
  /**
   * 设置视觉数据变量方法
   */
  [MutationTypes.SET_EDITAPPEARANCE]=(state, {datas})=>{
    state.AppearanceDetailList = datas;
  };
}
export  default
{
  namespaced: true,
  state:new AppearanceStore(),
  getters:new AppearanceGetters(),
  mutations:new AppearanceMutations(),
  actions:new AppearanceActions()
};


