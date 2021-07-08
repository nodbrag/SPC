<template>
    <!-- <div>
        <div class="box_table appearance">
            <div class="header">
                <el-form :model="list" :inline="true" class="demo-form-inline">
                    <el-form-item label="Total Qty: "><span>{{list.totalQty}}</span></el-form-item>
                    <el-form-item label="OK: "><span style="color:#5BBA53">{{list.OK}}</span></el-form-item>
                    <el-form-item label="NG: "><span style="color:#FF6464">{{list.NG}}</span></el-form-item>
                    <el-form-item label="Yield: "><span>{{list.yield}}</span></el-form-item>
                    <el-form-item label="Cycle Time: "><span>{{list.cycleTime}}</span></el-form-item>
                </el-form>
            </div> -->
            <!-- <el-table
                :data="tableData.filter(data => !search || data.batch.toLowerCase().includes(search.toLowerCase()))"
                :default-sort = "{prop: 'number', order: 'descending'}"
                :span-method="objectSpanMethod"
                stripe
                border
                style="width: 100%">
                <el-table-column
                label="编号"
                prop="code">
                </el-table-column>
                <el-table-column
                label="缺陷"
                prop="defectItem">
                </el-table-column>
                <el-table-column
                label="不良数量"
                prop="badQuantity">
                </el-table-column>
                <el-table-column
                label="视觉检测机号"
                prop="testingMachineNumber">
                </el-table-column>
                <el-table-column
                label="因果分析"
                prop="reason">
                </el-table-column>
            </el-table> 
            
        </div>
    </div>-->
    <el-row class="warp">
        <el-col :span="24" class="warp-main box_table" v-loading="loading" element-loading-text="拼命加载中">
            <el-table class="tableCss" :data="AppearanceDetailList" highlight-current-row @selection-change="selectInfos" stripe style="width: 100%;">
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
        </el-col>
    </el-row>
</template>
<script>
  import AppearanceView from '../../../View/AppearanceView';
  export default new AppearanceView()
</script>