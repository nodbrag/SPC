import  Vue from 'vue';
import  Vuex from  'vuex';
import  UserStore from './modules/UserStore'
import  TopStore from './modules/TopStore'
import  CommonStore from './modules/CommonStore'
import  RoleStore from './modules/RoleStore'
import  AuthStore from './modules/AuthStore'
import CommonDictionaryStore from './modules/CommonDictionaryStore'
import ProductStore from './modules/ProductStore'
import WorkProcessStore from './modules/WorkProcessStore'
import DefectItemStore from './modules/DefectItemStore'
import  EquipmentStore from './modules/EquipmentStore'
import  EquipmentClassStore from './modules/EquipmentClassStore'
import  TaskStore from './modules/TaskStore'
import  ParameterStore from './modules/ParameterStore'
import  InspectionParamStore from './modules/InspectionParamStore'
import SpcAnalyseStore from './modules/SpcAnalyseStore'
import AppearanceStore from './modules/AppearanceStore'
import UserApi from "../api/UserApi";
import MutationTypes from './MutationTypes'
import RoleApi from "../api/RoleApi";
import CommonDictionaryApi from "../api/CommonDictionaryApi";
import ProductApi from '../api/ProductApi'
import  WorkProcessApi from '../api/WorkProcessApi'
import  DefectItemApi from '../api/DefectItemApi'
import  EquipmentApi from '../api/EquipmentApi'
import  EquipmentClassApi from '../api/EquipmentClassApi'
import  TaskApi from '../api/TaskApi'
import  ParameterApi from '../api/ParameterApi'
import  InspectionParamApi from '../api/InspectionParamApi'
import  SpcAnalyseApi from '../api/SpcAnalyseApi'
import  AppearanceApi from '../api/AppearanceApi'

//注入插件Vuex
Vue.use(Vuex);
let store= new Vuex.Store({
  modules: {
     UserStore
    ,TopStore
    ,CommonStore
    ,RoleStore
    ,AuthStore
    ,CommonDictionaryStore
    ,ProductStore
    ,WorkProcessStore,
    DefectItemStore,
    EquipmentStore,
    EquipmentClassStore,
    TaskStore,
    ParameterStore,
    InspectionParamStore,
    SpcAnalyseStore,
    AppearanceStore
  }
});
/**
 * 全局注册Api
 */
store.commit('SpcAnalyseStore/' + MutationTypes.SET_API, new SpcAnalyseApi(), {root: true});
store.commit('EquipmentClassStore/' + MutationTypes.SET_API, new EquipmentClassApi(), {root: true});
store.commit('EquipmentStore/' + MutationTypes.SET_API, new EquipmentApi(), {root: true});
store.commit('DefectItemStore/' + MutationTypes.SET_API, new DefectItemApi(), {root: true});
store.commit('WorkProcessStore/' + MutationTypes.SET_API, new WorkProcessApi(), {root: true});
store.commit('ProductStore/' + MutationTypes.SET_API, new ProductApi(), {root: true});
store.commit('UserStore/' + MutationTypes.SET_API, new UserApi(), {root: true});
store.commit('RoleStore/' + MutationTypes.SET_API, new RoleApi(), {root: true});
store.commit('TaskStore/' + MutationTypes.SET_API, new TaskApi(), {root: true});
store.commit('ParameterStore/' + MutationTypes.SET_API, new ParameterApi(), {root: true});
store.commit('InspectionParamStore/' + MutationTypes.SET_API, new InspectionParamApi(), {root: true});
store.commit('AppearanceStore/' + MutationTypes.SET_API, new AppearanceApi(), {root: true});
store.commit('CommonDictionaryStore/' + MutationTypes.SET_API, new CommonDictionaryApi(), {root: true});
export  default store;
