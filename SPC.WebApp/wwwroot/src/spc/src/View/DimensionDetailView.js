import BaseView, {BaseComputed, BaseMethods} from "./BaseView";
import TableToolBar from '@/components/TableToolBar/TableToolBar.vue'
import Pagination from '@/components/Pagination/Pagination.vue'
import {mapActions, mapGetters} from "vuex";
class DimensionDetailMethods extends  BaseMethods{
    get MapMethods() {
        return {  ...mapActions('TaskStore',['bindDimensionDetailInfos'])}
    }
  handleCurrentChange= function(val){
    this.pageChange(val);
    this.searchDimensionDetail();
  };
  // 修改分页数重新加载列表
  maxResultCountSelect = function(maxResultCount){
    this.pageSelect(maxResultCount);
    this.searchDimensionDetail();
  }
    /**
    * 汇总数据绑定方法
    */
  searchDimensionDetail=function(){
    this.bindDimensionDetailInfos(this.$route.query.id).then((datas)=>{
      //this.$message.success({showClose: true, message: '数据加载完成', duration: 2000});
    }).catch((error)=>{
      this.$message.error({showClose: true, message: '数据加载失败:' + error, duration: 2000});
    });
  };
}
class DimensionDetailComputed extends  BaseComputed{
  /**
   * 返回vuex 混入的计算属性
   * @returns {{[p: string]: () => any}}
   * @constructor
   */
  get MapComputed() {
    return { ...mapGetters('TaskStore',['DimensionDetailList'])};
  }
}
let view={
  methods:new DimensionDetailMethods(),
  computed:new DimensionDetailComputed()
};

export default class DimensionDetailView extends  BaseView {
  name='DimensionDetailView';
  get store() {
    return "TaskStore";
  }
  constructor(){
    super(view);

  }
  mounted=function () {
    // this.filter.batchNo=;
    this.pageChange(1);
    this.searchDimensionDetail();
  };
  components={
    TableToolBar,
    Pagination,
  }
}
