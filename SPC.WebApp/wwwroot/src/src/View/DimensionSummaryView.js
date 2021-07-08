import BaseView, {BaseComputed, BaseMethods} from "./BaseView";
import TableToolBar from '@/components/TableToolBar/TableToolBar.vue'
import Pagination from '@/components/Pagination/Pagination.vue'
import {mapActions, mapGetters} from "vuex";
import  LittleChart from "@/components/Chart/LittleChart";
class DimensionSummaryMethods extends  BaseMethods{
    get MapMethods() {
        return {  ...mapActions('TaskStore',['bindSummaryInfos'])}
    }
    /**
    * 汇总数据绑定方法
    */
  searchSummary=function(){
    let parms = {batchNo:this.$route.query.id};//批号
    this.bindSummaryInfos(parms).then((datas)=>{
      //this.$message.success({showClose: true, message: '数据加载完成', duration: 2000});
    }).catch((error)=>{
      this.$message.error({showClose: true, message: '数据加载失败:' + error, duration: 2000});
    });
  };
}
class DimensionSummaryComputed extends  BaseComputed{
  /**
   * 返回vuex 混入的计算属性
   * @returns {{[p: string]: () => any}}
   * @constructor
   */
  get MapComputed() {
    return { ...mapGetters('TaskStore',['SummaryList'])};
  }
}
let view={
  methods:new DimensionSummaryMethods(),
  computed:new DimensionSummaryComputed()
};

export default class DimensionSummaryView extends  BaseView {
  name='DimensionSummaryView';
  get store() {
    return "TaskStore";
  }
  constructor(){
    super(view);

  }
  mounted=function () {
    this.pageChange(1);
    this.searchSummary();
  };
  components={
    TableToolBar,
    Pagination,
    LittleChart
  }
}
