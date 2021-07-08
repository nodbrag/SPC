import MutationTypes from "../MutationTypes";
import Vue from 'vue';

let vue=new Vue();
/**
 * state  基类
 */
export  class  BaseState {
  /**
   * 数据列表数组定义
   * @type {Array}
   */
  datalist = [];
  /**
   * 消息定义
   * @type {string}
   */
  mess="";
  /**
   * 编辑Form对象
   * @type {{}}
   */
  editForm = { };
  /**
   * 新增Form对象
   * @type {{}}
   */
  addForm = { };
  /**
   * 选择的数据列表
   * @type {Array}
   * @public
   */
  selectdatas = [];

  /**
   * 搜索过滤条件
   * @type {{UserName: string}}
   * @public
   */
  filter = { };

  /**
   * 验证规则
   */
  editFormRules = {};
   /**
   * api对象
   * */
   api={};

  maxHeight= window.innerHeight - 220;
  
  constructor(obj){
    this.addForm=obj;
    this.editForm=obj;
  }
}

/**
 * getters 基类
 */
export  class BaseGetters
{
  mes=state => state.mes;
  datalist= state => state.datalist;
  filter=state=>state.filter;
  selectdatas=state=>state.selectdatas;
  editFormRules=state=>state.editFormRules;
  editForm=state=>state.editForm;
  addForm=state=>state.addForm;
  api=state=>state.api;
  maxHeight=state=>state.maxHeight;
}
/**
 * Mutation 基类
 */
export  class  BaseMutations {
  [MutationTypes.SET_LISTData]=(state, {datas})=>{
    state.datalist = datas;
  };
  [MutationTypes.SET_SELECTUSERS]=(state, selectdatas)=>{
    state.selectdatas = selectdatas;
  };
  [MutationTypes.SET_EDITFORM]=(state,editobj)=>{
    state.editForm = editobj;
  };
  [MutationTypes.SET_API]=(state,api)=>{
    state.api=api;
  };
  [MutationTypes.SET_MAXHEIGHT]=(state,maxHeight)=>{
    state.maxHeight=maxHeight;
  }
}
/**
 * action 基类
 */
export class  BaseActions {
   /**
   * 绑定列表信息
   * @param commit
   * @param state
   * @param rootGetters
   */
   bindInfos=({commit,state, rootGetters })=>{
    let maxResultCount = rootGetters['CommonStore/maxResultCount'];
    let skipCount = rootGetters['CommonStore/skipCount'];
    let parms = {filter: state.filter, maxResultCount: maxResultCount, skipCount: skipCount};
    console.log(JSON.stringify(parms));
    commit('CommonStore/' + MutationTypes.SET_LOADING, true, {root: true});
    return new Promise((resolve, reject) => {
       state.api.getAll(parms).then(data => {
        let success = data.success;
        if (success){
          console.log(JSON.stringify(data));
          let datas = data.result.items;
          let count=data.result.totalCount;
          commit(MutationTypes.SET_LISTData, {datas});
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
  /**
   * 设置选中记录
   * @param commit
   * @param selectusers
   */
  selectInfos=({commit},selectdatas)=>{
    commit(MutationTypes.SET_SELECTUSERS, selectdatas);
  };
  /**
   * 显示编辑弹出框
   * @param commit
   * @param row
   */
  showEditDialog=({commit},row)=>{
    commit(MutationTypes.SET_EDITFORM, Object.assign({}, row));
    commit('CommonStore/' + MutationTypes.SET_EDITFORMVISIBLE, true, {root: true});
  };
  closeEditDialog=({commit})=>{
    commit('CommonStore/' + MutationTypes.SET_EDITFORMVISIBLE, false, {root: true});
  };
  showAddDialog=({commit})=>{
    commit('CommonStore/' + MutationTypes.SET_AddFORMVISIBLE, true, {root: true});
  };
  closeAddDialog=({commit})=>{
    commit('CommonStore/' + MutationTypes.SET_AddFORMVISIBLE, false, {root: true});
  };
  showImportDialog=({commit})=>{
    commit('CommonStore/' + MutationTypes.SET_IMPORTFORMVISIBLE, true, {root: true});
  };
  closeImportDialog=({commit})=>{
    commit('CommonStore/' + MutationTypes.SET_IMPORTFORMVISIBLE, false, {root: true});
  };
  /**
   * 新增用户
   * @param commit
   * @param state
   * @returns {Promise<any>}
   */
  create=({commit,state,rootGetters})=>{

    let obj = Object.assign({}, state.addForm);
    console.log(JSON.stringify(obj));
    commit('CommonStore/' + MutationTypes.SET_LOADING, true, {root: true});
    return new Promise((resolve, reject) => {
      state.api.create(obj).then(data=>{
        let success = data.success;
        if (success) {
          this.bindInfos.call(this,{commit,state,rootGetters});
          resolve();
        }else{
          reject(data.message);
        }
        commit('CommonStore/' + MutationTypes.SET_AddFORMVISIBLE, false, {root: true});
        commit('CommonStore/' + MutationTypes.SET_LOADING, false, {root: true});
      }).then(error=>{
        commit('CommonStore/' + MutationTypes.SET_AddFORMVISIBLE, false, {root: true});
        commit('CommonStore/' + MutationTypes.SET_LOADING, false, {root: true});
        reject(error);
      })
    });
  };
  /**
   * 编辑信息
   * @param commit
   * @param user
   * @returns {Promise<any>}
   */
  update=({commit,state,rootGetters})=>{
    let obj = Object.assign({}, state.editForm);
    commit('CommonStore/' + MutationTypes.SET_LOADING, true, {root: true});
    return new Promise((resolve, reject) => {
      state.api.update(obj).then(data=>{
        let success = data.success;
        if (success) {
          this.bindInfos.call(this,{commit,state,rootGetters});
          resolve();
        }else{
          reject(data.message);
        }
        commit('CommonStore/' + MutationTypes.SET_EDITFORMVISIBLE, false, {root: true});
        commit('CommonStore/' + MutationTypes.SET_LOADING, false, {root: true});
      }).then(error=>{
        commit('CommonStore/' + MutationTypes.SET_LOADING, false, {root: true});
          reject(error);
      })
    });
  };
  /**
   * 删除信息
   * @param commit
   * @param id
   * @returns {Promise<any>}
   */
  delete=({commit,state,rootGetters},parms)=>{
    return new Promise((resolve, reject) => {
      vue.$confirm('确认删除该记录吗?', '提示', {type: 'warning'}).then(() => {
        commit('CommonStore/' + MutationTypes.SET_LOADING, true, {root: true});
       state.api.delete(parms).then(data => {
          let success = data.success;
          if (success) {
            this.bindInfos.call(this,{commit,state,rootGetters});
            resolve();
          } else {
            reject(data.message);
          }
          commit('CommonStore/' + MutationTypes.SET_LOADING, false, {root: true});
        }).then(error => {
         commit('CommonStore/' + MutationTypes.SET_LOADING, false, {root: true});
          reject(error);
        })
      }).catch(()=>{
      });
    });
  };
}

