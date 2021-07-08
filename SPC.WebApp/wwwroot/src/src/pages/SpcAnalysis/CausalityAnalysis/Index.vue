<template>
    <div class="causality box_table" style="padding:20px 45px 20px 38px">
        <!--工具条-->
        <div class="table_tool">
            <div class="box_search">
              <el-form ref="form" :model="editForm" :inline="true" class="demo-form-inline" style="line-height:26px">
                <el-form-item><span style="font-size:14px">{{editForm.productName}}</span></el-form-item>
                <el-form-item><span style="font-size:14px">{{editForm.equipmentName}}</span></el-form-item>
                <el-form-item><span style="font-size:14px">{{editForm.BeginDateTime }}</span></el-form-item> /
                <el-form-item><span style="font-size:14px">{{editForm.EndDateTime  }}</span></el-form-item>
                <el-button type="primary" icon="el-icon-circle-plus-outline" style="float: right"  size="mini" @click="showEditDialog" >时段查询</el-button>
                </el-form>
            </div>
        </div>
        <el-row class="warp">
            <el-col :span="24">
            <el-card style="height:460px;">
                <ParetoChart ref="mychild1"  id="myChart3" width="100%" height="420px"  :xAxisValue="pSortChart.xAxisValue"  :PValue="pSortChart.pValue" ></ParetoChart>
            </el-card>
            </el-col>
        </el-row>
      <el-table :data="badList" highlight-current-row @selection-change="selectInfos" stripe
                style="width: 100%;">

        <el-table-column type="index"  width="60">
        </el-table-column>
        <el-table-column prop="defectItemName" label="缺陷"  sortable>
        </el-table-column>
        <el-table-column prop="badNum" label="不良数量"  sortable>
        </el-table-column>
        <el-table-column prop="badRate" label="不良率"  sortable>
        </el-table-column>
        <el-table-column prop="equipmentName" label="视觉检测机号"  sortable>
        </el-table-column>
      </el-table>

        <!--弹框-->
      <el-dialog  :visible.sync ="editFormVisible"   :before-close="closeEditDialog">
        <div slot="title">查询时段</div>
        <el-form :model="filter" label-width="120px" :rules="editFormRules" ref="editForm">
          <el-form-item label="开始时间:" prop="BeginDateTime">
            <el-date-picker v-model="filter.BeginDateTime" type="datetime" placeholder="选择日期时间">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="结束时间:" prop="EndDateTime">
            <el-date-picker v-model="filter.EndDateTime" type="datetime" placeholder="选择日期时间">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="检测机号:" prop="detection">
            <el-select v-model="filter.equipmentId"  placeholder="请选择">
              <el-option
                v-for="item in equipmentOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="产品名称:" prop="productName">
            <el-select v-model="filter.productId"  placeholder="请选择">
              <el-option
                v-for="item in productOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
          </el-form-item>
        </el-form>
        <div class="sub-btn">
          <el-button @click="search" :loading="loading">查询</el-button>
        </div>
      </el-dialog>
    </div>
</template>
<script>
  import CausalityAnalysisView from '../../../View/CausalityAnalysisView';
  export default new CausalityAnalysisView()
</script>
<!--<script>

  import  ParetoChart from "../../../components/Chart/ParetoChart";
  export default {
    data() {
      return {
        filter:{},
        addFormVisible:true,
        addForm:{},
        PLA:[100,90,78,70,67,60,56,45,40,37,36,30,29,28,20,15,14,12,8,4],
        xAxisValue2:['窗口毛刺','窗口变形','裂纹','内腔粘料','大面变形','毛刺','鼓泡','沙眼','脏化','顶角缺料','侧面裂纹','侧面粘料','熔接痕','底部缺料','疑似不良','凸台划伤','碰伤','大面毛刺','大面脏污','合模线'],
        search:'',
        tableData: [
            {
            code: '1',
            defectItem: '底部毛边',
            badQuantity:'268(73.1%)',
            testingMachineNumber:'LH-801',
            reason:'1.员工培训目标不明确（人）',
            },
            {
            code: '1',
            defectItem: '底部毛边',
            badQuantity:'268(73.1%)',
            testingMachineNumber:'LH-801',
            reason:'2.注塑材料拉伸不合格（料）',
            },
            {
            code: '1',
            defectItem: '底部毛边',
            badQuantity:'268(73.1%)',
            testingMachineNumber:'LH-801',
            reason:'3.模具磨损（机）',
            },
            {
            code: '2',
            defectItem: '侧面划痕',
            badQuantity:'268(12.1%)',
            testingMachineNumber:'LH-801',
            reason:'1.摆件操作',
            },
            {
            code: '2',
            defectItem: '侧面划痕',
            badQuantity:'268(73.1%)',
            testingMachineNumber:'LH-801',
            reason:'2.摆件环境为保持清洁（环）',
            }
        ],
        spanArr:[],
      }
    },
    mounted: function () {
        // 组件创建完后获取数据，
        // 此时 data 已经被 observed 了
        this.getSpanArr(this.tableData);
    },
    methods: {
        getSpanArr(data) {　
            for (var i = 0; i < data.length; i++) {
                if (i === 0) {
                    this.spanArr.push(1);
                    this.pos = 0
                    } else {
                  // 判断当前元素与上一个元素是否相同
                    if (data[i].code === data[i - 1].code) {
                        this.spanArr[this.pos] += 1;
                        this.spanArr.push(0);
                    } else {
                        this.spanArr.push(1);
                        this.pos = i;
                    }
                }
            }
        },
        objectSpanMethod({ row, column, rowIndex, columnIndex }) {
            if (columnIndex === 0||columnIndex === 1||columnIndex === 2||columnIndex === 3) {
                const _row = this.spanArr[rowIndex];
                const _col = _row > 0 ? 1 : 0;
                return {
                    rowspan: _row,
                    colspan: _col
                }
            }
        },
        showAddDialog(){
            this.addFormVisible=true
        },
        timeintervalsearch(){
            this.filter={

            };
            this.addFormVisible=false;
            this.addForm.BeginDateTime=this.addForm.BeginDateTime.toLocaleString();
            this.addForm.EndDateTime=this.addForm.EndDateTime.toLocaleString();
            this.filter=this.addForm;
        }
    },
    components:{
        ParetoChart
    }
  }
</script>-->
<style lang="stylus" scope>
  @import '../../../common/common.stylus'
</style>
<style >
.causality .el-row::after{
    clear:none
}
.causality .warp .el-card{
    background:rgba(255,255,255,1);
    box-shadow:2px 2px 4px 0px rgba(54,125,254,0.26);
    border:1px solid rgba(234,234,234,1);
    margin-bottom: 25px
}
.causality .el-table{
    padding-right: 3px;
}
.causality .el-table td{
    border-bottom:1px solid #E5E5E5;
    border-right: 1px solid #E5E5E5;
    padding:3px 0
}
.causality .el-table th{
    border-right:1px solid rgba(0,80,225,1);
    border-bottom:1px solid rgba(0,80,225,1);
}
.causality .el-table th.is-leaf{
    border-bottom:none
}
.causality .el-table__header-wrapper{
    border-left:1px solid rgba(0,80,225,1);
    border-right:1px solid rgba(0,80,225,1);
}
.causality .el-table__body-wrapper{
    border-left:1px solid #E5E5E5;
    border-right:1px solid #E5E5E5;
}
.causality .el-table td .cell{
    line-height:14px;
    height:14px
}
@media screen and (min-width: 1500px) { 
  .causality {
    height:792px;
    overflow: overlay;
    margin-top: 0.1em;
  }
} 
@media screen and (max-width: 1366px) { 
  .causality {
    height:480px;
    overflow: overlay;
    margin-top: 0.1em;
  }
}
</style>
