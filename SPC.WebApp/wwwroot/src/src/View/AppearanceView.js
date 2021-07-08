import BaseView, {BaseComputed, BaseMethods} from "../View/BaseView";
import TableToolBar from '@/components/TableToolBar/TableToolBar.vue'
import Pagination from '@/components/Pagination/Pagination.vue'
import { mapActions,mapGetters } from "vuex";

class AppearanceMethods extends  BaseMethods{
  /**
   * 返回 vuex 混入的方法
   * @returns {{}}
   * @constructor
   */
  get MapMethods() {
    return {...mapActions('AppearanceStore',['bindAppearanceInfos'])};
  }
  /**
   * 离散数据详细绑定方法
  */
  searchAppearance=function(){
    this.pageChange(1);
    let parms = {batchNo:this.$route.query.id};//批号
    // alert($route.query.id);
    this.bindAppearanceInfos(parms).then((datas)=>{
      //this.$message.success({showClose: true, message: '数据加载完成', duration: 2000});
    }).catch((error)=>{
      this.$message.error({showClose: true, message: '数据加载失败:' + error, duration: 2000});
    });
  };
}
class AppearanceComputed extends  BaseComputed{
  get MapComputed() {
    return { ...mapGetters('AppearanceStore',['AppearanceDetailList'])};
  }
}
let view={
  methods:new AppearanceMethods(),
  computed:new AppearanceComputed()
};

export default class AppearanceView extends  BaseView {
  name='AppearanceView';
  get store() {
    return "AppearanceStore";
  }
  constructor(){
    super(view);
  }
  /**
   * 离散数据调用绑定方法
  */
  mounted=function () {
    this.pageChange(1);
    this.searchAppearance();
  }
  components={
    TableToolBar,
    Pagination
  }
}
