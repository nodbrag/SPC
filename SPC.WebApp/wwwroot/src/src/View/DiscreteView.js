import BaseView, {BaseComputed, BaseMethods} from "../View/BaseView";
import TableToolBar from '@/components/TableToolBar/TableToolBar.vue'
import Pagination from '@/components/Pagination/Pagination.vue'
import { mapActions,mapGetters } from "vuex";

class DiscreteMethods extends  BaseMethods{
  /**
   * 返回 vuex 混入的方法
   * @returns {{}}
   * @constructor
   */
  get MapMethods() {
    return {...mapActions('TaskStore',['bindDiscreteInfos','createTasks','deleteBatchNo'])};
  }
    /**
   * 分页加载
   * @param val
   */
  handleCurrentChange= function(val){
    this.pageChange(val);
    this.searchDiscrete();
  };

  // 修改分页数重新加载列表
  maxResultCountSelect = function(maxResultCount){
    this.pageSelect(maxResultCount);
    this.searchDiscrete();
  }
  /**
   * 离散数据绑定方法
  */
  searchDiscrete=function(){
    this.bindDiscreteInfos().then((datas)=>{
      //this.$message.success({showClose: true, message: '数据加载完成', duration: 2000});
    }).catch((error)=>{
      this.$message.error({showClose: true, message: '数据加载失败:' + error, duration: 2000});
    });
  };
  /**
   * 添加离散数据方法
   * */
  addTasksList= function(){
    this.$refs.addForm.validate((valid) => {
      if (valid) {
        this.createTasks().then(data => {
          this.$refs['addForm'].resetFields();
          this.$message.success({showClose: true, message: '新增成功', duration: 2000});
        }).catch((error) => {
          this.$message.error({showClose: true, message: '新增失败:' + error, duration: 2000});
        })
      }
    });
  };
  /**
   * 跳转到详情页方法
   */
  jumpHtml = function (batchNo) {
    console.log(batchNo);
    this.$router.push({
      path: '/discrete/info',
      query: {
        id: batchNo
      }
    })
  };
  /**
   * 删除
   * @param key
   * @param val
   */
  delBatchNo= function(batchNo){
    let parms = {batchNo:batchNo};
    this.deleteBatchNo(parms).then(() => {
      this.$message.success({showClose: true, message: '删除成功', duration: 2000});
    }).catch((error) => {
      this.$message.error({showClose: true, message: '删除失败:' + error, duration: 2000});
    });
  };
}
class DiscreteComputed extends  BaseComputed{
  get MapComputed() {
    return { ...mapGetters('TaskStore',['DiscreteList','workProcess1Options','workProcess2Options','workProcess3Options','workProcess4Options'])
    ,...mapGetters('CommonDictionaryStore',['productOptions','equipmentOptions'])
    };
  }
}
let view={
  methods:new DiscreteMethods(),
  computed:new DiscreteComputed()
};

export default class DiscreteView extends  BaseView {
  name='DiscreteView';
  get store() {
    return "TaskStore";
  }
  constructor(){
    super(view);
  }
  /**
   * 离散数据调用绑定方法
  */
  mounted=function () {
    this.pageChange(1);
    this.searchDiscrete();
  }
  components={
    TableToolBar,
    Pagination
  }
}
