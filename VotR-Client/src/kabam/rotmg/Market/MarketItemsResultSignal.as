package kabam.rotmg.market {
import kabam.rotmg.messaging.impl.data.PlayerShopItem;

import org.osflash.signals.Signal;

public class MarketItemsResultSignal extends Signal {
    public function MarketItemsResultSignal() {
        super(Vector.<PlayerShopItem>);
    }
}
}