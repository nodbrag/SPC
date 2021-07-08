import BaseView, {BaseComputed, BaseMethods} from "../View/BaseView";
import TableToolBar from '@/components/TableToolBar/TableToolBar.vue'
import Pagination from '@/components/Pagination/Pagination.vue'
import { mapActions,mapGetters } from "vuex";

class DiscreteInfoMethods extends  BaseMethods{
  /**
   * 返回 vuex 混入的方法
   * @returns {{}}
   * @constructor
   */
  get MapMethods() {
    return {...mapActions('TaskStore',['bindTaskByBatchInfos','updateTaskBatch'])};
  }
  /**
   * 离散数据详细绑定方法
  */
  searchTaskBatch=function(){
    let parms = {batchNo:this.$route.query.id};//批号
    this.bindTaskByBatchInfos(parms).then((datas)=>{
      //this.$message.success({showClose: true, message: '数据加载完成', duration: 2000});
    }).catch((error)=>{
      this.$message.error({showClose: true, message: '数据加载失败:' + error, duration: 2000});
    });
  };
  /**
   * 编辑
   */
  editTaskBatch=  function(){
    let parms = {batchNo:this.$route.query.id};//批号
    this.$refs.editForm.validate((valid) => {
      if (valid) {
        this.updateTaskBatch(parms).then(data => {
          this.$refs['editForm'].resetFields();
          this.$message.success({showClose: true, message: '编辑成功', duration: 2000});
        }).catch((error) => {
          this.$message.error({showClose: true, message: '编辑失败:' + error, duration: 2000});
        })
      }
    });
  };
}
class DiscreteInfoComputed extends  BaseComputed{
  get MapComputed() {
    return { ...mapGetters('TaskStore',['TaskBatchList','workProcess1Options','workProcess2Options','workProcess3Options','workProcess4Options'])
     ,...mapGetters('CommonDictionaryStore',['productOptions','equipmentOptions'])
    };
  }
}
let view={
  methods:new DiscreteInfoMethods(),
  computed:new DiscreteInfoComputed()
};

export default class DiscreteInfoView extends  BaseView {
  name='DiscreteInfoView';
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
    this.searchTaskBatch();
  }
  components={
    TableToolBar,
    Pagination
  }
}
