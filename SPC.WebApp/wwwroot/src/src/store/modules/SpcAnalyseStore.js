import MutationTypes from "@/store/MutationTypes";
import {BaseActions, BaseGetters, BaseMutations, BaseState} from "./BaseStore";
import  moment from 'moment'

/**
 * 分析状态类
 */
class SpcAnalyseState extends  BaseState{
  constructor()
  {
    super({});

  }
  badChart= {"ucl":[],"lcl":[],"badCL":0,"okCL":0,"badRate":[],"okRate":[],"xAxisValue":[]};
  badList=[];
  pSortChart={"pValue":[],"xAxisValue":[]};
  filter = {  };
  /**
   * 对比
   * @type {{okCL: number, lcl: Array, badRate: Array, xAxisValue: Array, okRate: Array, badCL: number, ucl: Array}}
   */
  cbadChart= {"ucl":[],"lcl":[],"badCL":0,"okCL":0,"badRate":[],"okRate":[],"xAxisValue":[]};
  cbadList=[];
  cpSortChart={"pValue":[],"xAxisValue":[]};
  compareFilter={};
  compareForm={};
  editFormRules =
    {
      BeginDateTime: [
        {required: true, message: '请选择开始时间', trigger: 'blur'}
      ],
      EndDateTime: [
        {required: true, message: '请选择结束时间', trigger: 'blur'}
      ],
      productId: [
        {required: true, message: '请选择产品信息', trigger: 'blur'}
      ]
      ,equipmentId: [
        {required: true, message: '请选择设备信息', trigger: 'blur'}
      ]
    };
}
/**
 * action 类
 */
class SpcAnalyseActions extends BaseActions
{
  /**
   * 获取不良品控制接口
   * @param commit
   * @param state
   * @param rootGetters
   * @param api
   * @returns {Promise<any>}
   */
  getBadControlData=({commit,state, rootGetters })=>{

    let parms = Object.assign({}, state.filter);
    console.log(JSON.stringify(state.filter));
    if(state.filter.BeginDateTime==undefined||state.filter.EndDateTime==undefined) {
      return new Promise((resolve, reject) => {
        reject("请选择开始或结束时间");
      });
    };
    if(state.filter.productId==undefined||state.filter.equipmentId==undefined) {
      return new Promise((resolve, reject) => {
        reject("请选择产品或设备");
      });
    };
    let searchForm={};
    searchForm.BeginDateTime= moment(state.filter.BeginDateTime).format("YYYY-MM-DD HH:mm");
    searchForm.EndDateTime=moment(state.filter.EndDateTime).format("YYYY-MM-DD HH:mm");
    searchForm.productName=JSON.parse(localStorage.getItem("product")).find((obj) => state.filter.productId==obj.id).name;
    searchForm.equipmentName=JSON.parse(localStorage.getItem("equipment")).find((obj) => obj.id==state.filter.equipmentId).name;
    commit(MutationTypes.SET_EDITFORM, searchForm);
    commit('CommonStore/' + MutationTypes.SET_LOADING, true, {root: true});
    return new Promise((resolve, reject) => {
      state.api.getBadControlData(parms).then(data => {
        console.log(JSON.stringify(data));
        let success = data.success;
        if (success){
          let datas = data.result;
          commit(MutationTypes.SET_BADCHART, {datas});
          resolve(data);
        } else {
          reject(data.message)
        }
        commit('CommonStore/' + MutationTypes.SET_LOADING, false, {root: true});
      }).catch(error=>{
        reject(error);
      })
    });
  };

  /**
   * 因果分析
   * @param commit
   * @param state
   * @param rootGetters
   * @returns {Promise<any>}
   */
  getCausalityAnalysisData=({commit,state, rootGetters })=>{

    let parms = Object.assign({}, state.filter);
    console.log(JSON.stringify(state.filter));
    let searchForm={};
    if(state.filter.BeginDateTime==undefined||state.filter.EndDateTime==undefined) {
      return new Promise((resolve, reject) => {
        reject("请选择开始或结束时间");
      });
    };
    if(state.filter.productId==undefined||state.filter.equipmentId==undefined) {
      return new Promise((resolve, reject) => {
        reject("请选择产品或设备");
      });
    };
    searchForm.BeginDateTime= moment(state.filter.BeginDateTime).format("YYYY-MM-DD HH:mm");
    searchForm.EndDateTime=moment(state.filter.EndDateTime).format("YYYY-MM-DD HH:mm");
    searchForm.productName=JSON.parse(localStorage.getItem("product")).find((obj) => state.filter.productId==obj.id).name;
    searchForm.equipmentName=JSON.parse(localStorage.getItem("equipment")).find((obj) => obj.id==state.filter.equipmentId).name;
    commit(MutationTypes.SET_EDITFORM, searchForm);
    commit('CommonStore/' + MutationTypes.SET_LOADING, true, {root: true});
    return new Promise((resolve, reject) => {
      state.api.getCausalityAnalysisData(parms).then(data => {
        console.log(JSON.stringify(data));
        let success = data.success;
        if (success){
          let pListDtos = data.result.pListDtos;
          let platoDto = data.result.platoDto;
          commit(MutationTypes.SET_BADLIST, {pListDtos});
          commit(MutationTypes.SET_PSORTCHART, {platoDto});
          resolve(data);
        } else {
          reject(data.message)
        }
        commit('CommonStore/' + MutationTypes.SET_LOADING, false, {root: true});
      }).catch(error=>{
        reject(error);
      })
    });
  };
  /**
   * 对比分析
   * @param commit
   * @param state
   * @param rootGetters
   * @returns {Promise<any>}
   */
  getContrastiveAnalysisData=({commit,state, rootGetters })=>{

    let parms = Object.assign({}, state.filter);
    console.log(JSON.stringify(state.filter));
    let searchForm={};
    if(state.filter.BeginDateTime==undefined||state.filter.EndDateTime==undefined) {
      return new Promise((resolve, reject) => {
        reject("请选择开始或结束时间");
      });
    };
    if(state.filter.productId==undefined||state.filter.equipmentId==undefined) {
      return new Promise((resolve, reject) => {
        reject("请选择产品或设备");
      });
    };
    searchForm.BeginDateTime= moment(state.filter.BeginDateTime).format("YYYY-MM-DD HH:mm");
    searchForm.EndDateTime=moment(state.filter.EndDateTime).format("YYYY-MM-DD HH:mm");
    searchForm.productName=JSON.parse(localStorage.getItem("product")).find((obj) => state.filter.productId==obj.id).name;
    searchForm.equipmentName=JSON.parse(localStorage.getItem("equipment")).find((obj) => obj.id==state.filter.equipmentId).name;
    commit(MutationTypes.SET_EDITFORM, searchForm);
    commit('CommonStore/' + MutationTypes.SET_LOADING, true, {root: true});
    return new Promise((resolve, reject) => {
      state.api.getContrastiveAnalysisData(parms).then(data => {
        console.log(JSON.stringify(data));
        let success = data.success;
        if (success){
          let pListDtos = data.result.pListDtos;
          let platoDto = data.result.platoDto;
          let datas=data.result.pDto;
          commit(MutationTypes.SET_BADLIST, {pListDtos});
          commit(MutationTypes.SET_PSORTCHART, {platoDto});
          commit(MutationTypes.SET_BADCHART, {datas});
          resolve(data);
        } else {
          reject(data.message)
        }
        commit('CommonStore/' + MutationTypes.SET_LOADING, false, {root: true});
      }).catch(error=>{
        reject(error);
      })
    });
  };
  getCompareContrastiveAnalysisData=({commit,state, rootGetters })=>{

    let parms = Object.assign({}, state.compareFilter);
    console.log(JSON.stringify(state.compareFilter));
    let searchForm={};
    if(state.compareFilter.BeginDateTime==undefined||state.compareFilter.EndDateTime==undefined) {
      return new Promise((resolve, reject) => {
        reject("请选择开始或结束时间");
      });
    };
    if(state.compareFilter.productId==undefined||state.compareFilter.equipmentId==undefined) {
      return new Promise((resolve, reject) => {
        reject("请选择产品或设备");
      });
    };
    searchForm.BeginDateTime= moment(state.compareFilter.BeginDateTime).format("YYYY-MM-DD HH:mm");
    searchForm.EndDateTime=moment(state.compareFilter.EndDateTime).format("YYYY-MM-DD HH:mm");
    searchForm.productName=JSON.parse(localStorage.getItem("product")).find((obj) => state.compareFilter.productId==obj.id).name;
    searchForm.equipmentName=JSON.parse(localStorage.getItem("equipment")).find((obj) => obj.id==state.compareFilter.equipmentId).name;
    commit(MutationTypes.SET_COMPAREFORM, searchForm);
    commit('CommonStore/' + MutationTypes.SET_LOADING, true, {root: true});
    return new Promise((resolve, reject) => {
      state.api.getContrastiveAnalysisData(parms).then(data => {
        console.log(JSON.stringify(data));
        let success = data.success;
        if (success){
          let pListDtos = data.result.pListDtos;
          let platoDto = data.result.platoDto;
          let datas=data.result.pDto;
          commit(MutationTypes.SET_CBADLIST, {pListDtos});
          commit(MutationTypes.SET_CPSORTCHART, {platoDto});
          commit(MutationTypes.SET_CBADCHART, {datas});
          resolve(data);
        } else {
          reject(data.message)
        }
        commit('CommonStore/' + MutationTypes.SET_LOADING, false, {root: true});
      }).catch(error=>{
        reject(error);
      })
    });
  };
  /**
   * 显示搜索框
   * @param commit
   */
  showSearchDialog=({commit})=>{
    commit('CommonStore/' + MutationTypes.SET_EDITFORMVISIBLE, false, {root: true});
    commit('CommonStore/' + MutationTypes.SET_EDITFORMVISIBLE, true, {root: true});
  };
  /**
   * 关闭搜索框
   * @param commit
   */
  closeSearchDialog=({commit})=>{
    commit('CommonStore/' + MutationTypes.SET_EDITFORMVISIBLE, false, {root: true});
  };
};


/**
 * getters 类
 */
class SpcAnalyseGetters  extends  BaseGetters{
  badChart=state=>state.badChart;
  badList=state=>state.badList;
  pSortChart=state=>state.pSortChart;
  cbadChart=state=>state.cbadChart;
  cbadList=state=>state.cbadList;
  cpSortChart=state=>state.cpSortChart;
  productOptions=state=>state.productOptions;
  equipmentOptions=state=>state.equipmentOptions;
  compareFilter=state=>state.compareFilter;
  compareForm=state=>state.compareForm;
}
/**
 * mutaions
 */
class SpcAnalyseMutations extends  BaseMutations{
  [MutationTypes.SET_BADLIST]=(state, {pListDtos})=>{

    state.badList = pListDtos;
  };

  [MutationTypes.SET_BADCHART]=(state, {datas})=>{
    state.badChart = datas;
  };
  [MutationTypes.SET_PSORTCHART]=(state, {platoDto})=>{
    state.pSortChart = platoDto;
  };
  [MutationTypes.SET_COMPAREFORM]=(state,editobj)=>{
    state.compareForm = editobj;
  };
  [MutationTypes.SET_CBADLIST]=(state, {pListDtos})=>{

    state.cbadList = pListDtos;
  };
  [MutationTypes.SET_CBADCHART]=(state, {datas})=>{
    state.cbadChart = datas;
  };
  [MutationTypes.SET_CPSORTCHART]=(state, {platoDto})=>{
    state.cpSortChart = platoDto;
  };
}
export  default
{
  namespaced: true,
  state:new SpcAnalyseState(),
  getters:new SpcAnalyseGetters(),
  mutations:new SpcAnalyseMutations(),
  actions:new SpcAnalyseActions()
};
