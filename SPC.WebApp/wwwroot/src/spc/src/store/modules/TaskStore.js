
import Task from "../../model/Task";
import MutationTypes from "../MutationTypes";
import {BaseActions, BaseGetters, BaseMutations, BaseState} from "./BaseStore";
import Vue from 'vue';

let vue=new Vue();
/**
 * 角色状态类
 */
class TaskStore extends  BaseState {
  constructor()
  {
      super(new Task());

  }
  filter={};
  /**
   * 离散数据列表变量
  */
  DiscreteList=[];
  TaskBatchList=[];
  SummaryList=[];
  DimensionDetailList=[];

  /**
   * 上传路径
   * @type {string}
   */
  uploadPath="";
  /**
   * 工序
   */
  workProcessOptions=[];
  workProcess1Options=[{id:1,name:'注射'}];
  workProcess2Options=[{id:2,name:'摆件'}];
  workProcess3Options=[{id:3,name:'烧结'}];
  workProcess4Options=[{id:4,name:'整形'}];
}
/**
 * action 基类
 */
export class TaskActions extends  BaseActions{
  /**
   * 绑定离散列表信息
   * @param commit
   * @param state
   * @param rootGetters
   */
  bindDiscreteInfos=({commit,state, rootGetters })=>{
    /**
     * 工序ID指定
     */
    state.addForm.workProcessId1 = 1;
    state.addForm.workProcessId2 = 2;
    state.addForm.workProcessId3 = 3;
    state.addForm.workProcessId4 = 4;
    let maxResultCount = rootGetters['CommonStore/maxResultCount'];
    let skipCount = rootGetters['CommonStore/skipCount'];
    let parms = {filter: state.filter, maxResultCount: maxResultCount, skipCount: skipCount};
    commit('CommonStore/' + MutationTypes.SET_LOADING, true, {root: true});
    return new Promise((resolve, reject) => {
      // alert(JSON.stringify(state.api));
       state.api.GetDiscreteList(parms).then(data => {
        let success = data.success;
        if (success){
          let datas = data.result.items;
          let count=data.result.totalCount;
          commit(MutationTypes.SET_EDITDISCRETE, {datas});
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
   * 创建多任务
   * @param commit
   * @param state
   * @returns {Promise<any>}
   */
  createTasks=({commit,state,rootGetters})=>{
    let parms=[];
    // let obj1={};//注射
    // let obj2={};//摆件
    // let obj3={};//烧结
    // let obj4={};//整形
    let obj = Object.assign({}, state.addForm);
    let obj1=new Task();
    let obj2=new Task();
    let obj3=new Task();
    let obj4=new Task();
    let day2 = new Date();
    day2.setTime(day2.getTime())
    obj1.productID    = obj.productId;
    obj1.batchNo      = obj.batchNo;
    obj1.workProcessID= obj.workProcessId1;
    obj1.equipmentID  = obj.equipmentId1;
    obj1.quantity     = obj.quantity1;
    obj1.beginDateTime= obj.beginDateTime1;
    obj1.endDateTime  = obj.beginDateTime2;
    obj1.userDefine1  = obj.userDefine1;
    obj1.userDefine2  = obj.userDefine2;
    obj2.productID    = obj.productId;
    obj2.batchNo      = obj.batchNo;
    obj2.workProcessID= obj.workProcessId2;
    obj2.equipmentID  = obj.equipmentId2;
    obj2.quantity     = obj.quantity2;
    obj2.beginDateTime= obj.beginDateTime2;
    obj2.endDateTime  = obj.beginDateTime3;
    obj3.productID    = obj.productId;
    obj3.batchNo      = obj.batchNo;
    obj3.workProcessID= obj.workProcessId3;
    obj3.equipmentID  = obj.equipmentId3;
    obj3.quantity     = obj.quantity3;
    obj3.beginDateTime= obj.beginDateTime3;
    obj3.endDateTime  = obj.beginDateTime4;
    obj4.productID    = obj.productId;
    obj4.batchNo      = obj.batchNo;
    obj4.workProcessID= obj.workProcessId4;
    obj4.equipmentID  = obj.equipmentId4;
    obj4.quantity     = obj.quantity4;
    obj4.beginDateTime= obj.beginDateTime4;
    obj4.endDateTime  = day2.getFullYear()+"-" + (day2.getMonth()+1) + "-" + day2.getDate();
    parms[0] = obj1;
    parms[1] = obj2;
    parms[2] = obj3;
    parms[3] = obj4;
    commit('CommonStore/' + MutationTypes.SET_LOADING, true, {root: true});
    return new Promise((resolve, reject) => {
      state.api.SetTasksList(parms).then(data=>{
        let success = data.success;
        if (success) {
          this.bindDiscreteInfos.call(this,{commit,state,rootGetters});
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
   * 绑定批号数据列表信息
   * @param commit
   * @param state
   * @param rootGetters
   */
  bindTaskByBatchInfos=({commit,state, rootGetters },parms)=>{
    commit('CommonStore/' + MutationTypes.SET_LOADING, true, {root: true});
    return new Promise((resolve, reject) => {

       state.api.GetTaskByBatchList(parms).then(data => {
        let success = data.success;
        if (success){
          // console.log(JSON.stringify(data));
          let datas = data.result;
          let count=data.result.totalCount;
          commit(MutationTypes.SET_EDITTASKBATCH, {datas});
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
  importDimensionData=({commit,state,rootGetters})=>{

    let obj = Object.assign({filePath:state.uploadPath}, state.addForm);
    let parms={filePath:state.uploadPath,ProductID:state.addForm.productId,EquipmentId:state.addForm.equipmentId,BatchNo:state.addForm.batchNo};
    commit('CommonStore/' + MutationTypes.SET_LOADING, true, {root: true});
    return new Promise((resolve, reject) => {
      state.api.importDimensionData(parms).then(data=>{
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
   * 上传
   * @param commit
   * @param state
   * @param rootGetters
   * @param parms
   * @returns {Promise<any>}
   */
  uploadExcel=({commit,state, rootGetters },parms)=>{
    commit('CommonStore/' + MutationTypes.SET_LOADING, true, {root: true});
    return new Promise((resolve, reject) => {
      state.api.uploadExcel(parms).then(data => {
        let success = data.success;
        if (success){
          let datas = data.result;
          let path=datas.path;
          commit(MutationTypes.SET_UPLOADPATH, {path});
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
   * 根据批号删除信息
   * @param commit
   * @param id
   * @returns {Promise<any>}
   */
  deleteBatchNo=({commit,state,rootGetters},parms)=>{
    return new Promise((resolve, reject) => {
      vue.$confirm('确认删除该记录吗?', '提示', {type: 'warning'}).then(() => {
      commit('CommonStore/' + MutationTypes.SET_LOADING, true, {root: true});
        state.api.deleteBatchNoList(parms).then(data => {
          let success = data.success;
          if (success) {
            this.bindDiscreteInfos.call(this,{commit,state,rootGetters});
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
  /**
   * 编辑信息
   * @param commit
   * @param user
   * @returns {Promise<any>}
   */
  updateTaskBatch=({commit,state,rootGetters},parms)=>{
    let obj = Object.assign({}, state.editForm);
    console.log(obj);
    commit('CommonStore/' + MutationTypes.SET_LOADING, true, {root: true});
    return new Promise((resolve, reject) => {
      state.api.update(obj).then(data=>{
        let success = data.success;
        if (success) {
          this.bindTaskByBatchInfos.call(this,{commit,state,rootGetters},parms);
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
   * 绑定汇总列表批号数据列表信息
   * @param commit
   * @param state
   * @param rootGetters
   */
  bindSummaryInfos=({commit,state, rootGetters },parms)=>{
    commit('CommonStore/' + MutationTypes.SET_LOADING, true, {root: true});
    return new Promise((resolve, reject) => {
       state.api.GetSummaryList(parms).then(data => {
        let success = data.success;
        if (success){
          // console.log(JSON.stringify(data));
          let datas = data.result;
          console.log(datas);
          let count=data.result.totalCount;
          commit(MutationTypes.SET_EDITSUMMARY, {datas});
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
   * 绑定汇总列表批号数据列表信息
   * @param commit
   * @param state
   * @param rootGetters
   */
  bindDimensionDetailInfos=({commit,state, rootGetters },par)=>{
    let maxResultCount = rootGetters['CommonStore/maxResultCount'];
    let skipCount = rootGetters['CommonStore/skipCount'];
    let parms;
    if (par!= null || par !=undefined) {
      parms = {filter: {batchNo:par}, maxResultCount: maxResultCount, skipCount: skipCount};
    }else{
       parms = {};
    }

    commit('CommonStore/' + MutationTypes.SET_LOADING, true, {root: true});
    return new Promise((resolve, reject) => {

       state.api.GetDimensionDetailList(parms).then(data => {
        let success = data.success;
        if (success){
          // console.log(JSON.stringify(data));
          let datas = data.result;
          let count=data.result.totalCount;
          commit(MutationTypes.SET_EDITDIMENSIONDETAIL, {datas});
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
class TaskGetters extends  BaseGetters {
  DiscreteList=state => state.DiscreteList;
  TaskBatchList=state => state.TaskBatchList;
  SummaryList=state => state.SummaryList;
  DimensionDetailList=state => state.DimensionDetailList;

  productOptions=state=>state.productOptions;
  equipmentOptions=state=>state.equipmentOptions;
  workProcess1Options=state=>state.workProcess1Options;
  workProcess2Options=state=>state.workProcess2Options;
  workProcess3Options=state=>state.workProcess3Options;
  workProcess4Options=state=>state.workProcess4Options;
  uploadPath=state=>state.uploadPath;
}
/**
 * mutaions
 */
class TaskMutations extends BaseMutations {
  /**
   * 设置离散数据变量方法
   */
  [MutationTypes.SET_EDITDISCRETE]=(state, {datas})=>{
    state.DiscreteList = datas;
  };
  /**
   * 设置离散数据详情变量方法
   */
  [MutationTypes.SET_EDITTASKBATCH]=(state, {datas})=>{
    state.TaskBatchList = datas;
  };
   /**
   * 设置测量数据汇总变量方法
   */
  [MutationTypes.SET_EDITSUMMARY]=(state, {datas})=>{
    state.SummaryList = datas;
  };
   /**
   * 设置测量数据详情变量方法
   */
  [MutationTypes.SET_EDITDIMENSIONDETAIL]=(state, {datas})=>{
    state.DimensionDetailList = datas;
  };

  /**
   *
   * 设置保持路径
   * @param state
   * @param datas
   */
  [MutationTypes.SET_UPLOADPATH]=(state, {path})=>{
    state.uploadPath = path;
  };
}
export  default
{
  namespaced: true,
  state:new TaskStore(),
  getters:new TaskGetters(),
  mutations:new TaskMutations(),
  actions:new TaskActions()
};


